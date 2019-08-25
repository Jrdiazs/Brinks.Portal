using Data.Repository;
using Entity;
using Entity.Request;
using System;
using System.Threading.Tasks;
using System.Transactions;
using Tools.String;

namespace Services
{
    /// <summary>
    /// Clase de negocio para autenticacion y cambio de contraseñas
    /// </summary>
    public class LoginServices : IDisposable, ILoginServices
    {
        /// <summary>
        /// Acceso a datos a la tabla UserApp
        /// </summary>
        private readonly IUserAppData _userAppData;

        /// <summary>
        /// Acceso a datos de la tabla parametros
        /// </summary>
        private readonly IParametersData _parametersData;

        /// <summary>
        /// Acceso a datos a las politicas globales
        /// </summary>
        private readonly IPolicyGlobalAppData _policyGlobalAppData;

        /// <summary>
        /// Accesi a datos a la tabla de sesiones
        /// </summary>
        private readonly ISessionData _sessionData;

        /// <summary>
        /// Instancia una clase de negocio para la tabla User
        /// </summary>
        /// <param name="userAppData">repositorios de datos para usuarios</param>
        /// <param name="parametersData">repositorio de datos para parametros</param>
        /// <param name="policyGlobalAppData">repositorios de datos para las politicas globales</param>
        /// <param name="sessionData">repositorios para las sesiones</param>
        public LoginServices(IUserAppData userAppData, IParametersData parametersData, IPolicyGlobalAppData policyGlobalAppData, ISessionData sessionData)
        {
            _userAppData = userAppData;
            _parametersData = parametersData;
            _policyGlobalAppData = policyGlobalAppData;
            _sessionData = sessionData;
        }

        /// <summary>
        /// Verifica si el usuario puede autencarse correctamente con usuario y contraseña
        /// </summary>
        /// <param name="login">login de usuario</param>
        /// <returns>modelo de autenticacion</returns>
        public async Task<SessionAuthentication> AsyncAutenticateUser(Login login)
        {
            try
            {
                UserApp userApp;
                PolicyView policy;
                string pwDecode = string.Empty;
                bool isAutenticate = false, valideNumberOfAttemps = false;
                int stateInactiveUser = 0, stateLockedUser = 0, numberOfAttemps = 0;

                var autenticate = new SessionAuthentication()
                {
                    IsAuthenticate = false,
                    TypeAutentication = TypeAutentication.Default
                };

                userApp = await _userAppData.UserFindByUser(login.UserName);

                if (null == userApp)
                {
                    autenticate.TypeAutentication = TypeAutentication.NotFound;
                    return autenticate;
                }

                policy = !userApp.PolicyId.HasValue ?
                   await _policyGlobalAppData.PolicyGetGlobal() :
                  await _policyGlobalAppData.PolicyFindById(userApp.PolicyId.Value);

                pwDecode = login.Password.Base64Decode();
                isAutenticate = userApp.UserPw == pwDecode.SHA1();
                stateInactiveUser = await _parametersData.ValueFindByKey<int>("StateInactiveUser");
                stateLockedUser = await _parametersData.ValueFindByKey<int>("StateLockedUser");

                if (0 != stateInactiveUser && userApp.UserStateId == stateInactiveUser)
                {
                    autenticate.TypeAutentication = TypeAutentication.Inactive;
                    return autenticate;
                }

                if (0 != stateLockedUser && userApp.UserStateId == stateLockedUser)
                {
                    autenticate.TypeAutentication = TypeAutentication.Locked;
                    return autenticate;
                }

                if (!isAutenticate)
                {
                    numberOfAttemps = policy.NumberOfAttemps;
                    valideNumberOfAttemps = 0 != numberOfAttemps;

                    userApp.UserNumberOfAttemps++;
                    userApp.UpdateDate = DateTime.Now;

                    if (valideNumberOfAttemps)
                    {
                        if (userApp.UserNumberOfAttemps >= numberOfAttemps)
                        {
                            autenticate.TypeAutentication = TypeAutentication.Locked;
                            userApp.UserStateId = stateLockedUser;
                        }
                    }

                    await _userAppData.UpdateAsync(userApp);
                    autenticate.TypeAutentication = TypeAutentication.NotFound;
                }
                else
                {
                    if (policy.NumberOfDaysExpirePw > 0)
                    {
                        DateTime dateUserLastPasswordChange = userApp.UserLastPasswordChange.AddDays(policy.NumberOfDaysExpirePw.Value);
                        if (dateUserLastPasswordChange.Date >= DateTime.Now.Date)
                            autenticate.TypeAutentication = TypeAutentication.ChangePw;
                    }

                    if (autenticate.TypeAutentication == TypeAutentication.Default)
                        autenticate.TypeAutentication = TypeAutentication.Ok;

                    userApp.UserNumberOfAttemps = 0;
                    userApp.UserLastDateEntry = DateTime.Now;
                    userApp.PolicyId = !userApp.PolicyId.HasValue ? policy.PolicyId : userApp.PolicyId;

                    var sessionId = Guid.NewGuid();
                    using (var tran = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                    {
                        await _userAppData.UpdateAsync(userApp);
                        await _sessionData.InsertKeyAsync<Guid>(new CurrentSession()
                        {
                            Active = true,
                            CreationDate = DateTime.Now,
                            SessionId = sessionId,
                            UserId = userApp.UserId
                        });

                        tran.Complete();
                    }

                   

                    autenticate.SessionId = sessionId;
                    autenticate.UserId = userApp.UserId;
                    autenticate.PolicyId = policy.PolicyId;
                    autenticate.IsAuthenticate = true;
                }

                return autenticate;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region [Dispose]

        private bool disposedValue = false; // Para detectar llamadas redundantes

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: elimine el estado administrado (objetos administrados).
                    if (null != _userAppData)
                        _userAppData.Dispose();

                    if (null != _parametersData)
                        _parametersData.Dispose();

                    if (null != _policyGlobalAppData)
                        _policyGlobalAppData.Dispose();

                    if (null != _sessionData)
                        _sessionData.Dispose();
                }

                // TODO: libere los recursos no administrados (objetos no administrados) y reemplace el siguiente finalizador.
                // TODO: configure los campos grandes en nulos.

                disposedValue = true;
            }
        }

        // TODO: reemplace un finalizador solo si el anterior Dispose(bool disposing) tiene código para liberar los recursos no administrados.
        // ~LoginBusiness() {
        //   // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
        //   Dispose(false);
        // }

        // Este código se agrega para implementar correctamente el patrón descartable.
        public void Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
            Dispose(true);
            // TODO: quite la marca de comentario de la siguiente línea si el finalizador se ha reemplazado antes.
            GC.SuppressFinalize(this);
        }

        #endregion [Dispose]
    }

    /// <summary>
    /// Clase de negocio para autenticacion y cambio de contraseñas
    /// </summary>
    public interface ILoginServices : IDisposable
    {
        /// <summary>
        /// Verifica si el usuario puede autencarse correctamente con usuario y contraseña
        /// </summary>
        /// <param name="login">login de usuario</param>
        /// <returns>modelo de autenticacion</returns>
        Task<SessionAuthentication> AsyncAutenticateUser(Login login);
    }
}