using Data.Repository;
using Entity;
using Services.Controls;
using System;

namespace Services
{
    /// <summary>
    /// Clase de negocio para la tabla User
    /// </summary>
    public class UserServices : IDisposable, IUserServices
    {
        /// <summary>
        /// Acceso a datos a la tabla UserApp
        /// </summary>
        private readonly IUserAppData _userAppData;

        /// <summary>
        /// Acceso a datos a los controles de usuario
        /// </summary>
        private readonly IControlsLanguageData _controlsLanguageData;

        /// <summary>
        /// Instancia una clase de negocio para la tabla User
        /// </summary>
        /// <param name="userAppData">repositorios de datos para usuarios</param>
        public UserServices(IUserAppData userAppData, IControlsLanguageData controlsLanguageData)
        {
            _userAppData = userAppData;
            _controlsLanguageData = controlsLanguageData;
        }

        /// <summary>
        /// Consulta un usuario por nombre de usuario
        /// </summary>
        /// <param name="userName">nombre de usuario</param>
        /// <returns>UserApp</returns>
        public UserApp UserFindByUser(string userName)
        {
            try
            {
                return _userAppData.UserFindByUser(userName);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Consulta un usuario en la base de datos por numero de documento
        /// </summary>
        /// <param name="document">numero de documento</param>
        /// <returns>UserApp</returns>
        public UserApp UserFindByDocument(string document)
        {
            try
            {
                return _userAppData.UserFindByDocument(document);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Consulta un usuario en la base de datos por correo electronico
        /// </summary>
        /// <param name="email">correo electronico</param>
        /// <returns>UserApp</returns>
        public UserApp UserFindByEmail(string email)
        {
            try
            {
                return _userAppData.UserFindByEmail(email);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Inserta un usuario nuevo en la base de datos
        /// </summary>
        /// <param name="user">usuario a crear</param>
        /// <param name="session">sesion del usuario</param>
        /// <returns>UserApp</returns>
        public UserApp UserAppInsert(UserApp user, UserSession session)
        {
            try
            {
                if (_userAppData.ExistUserByUserName(user))
                {
                    var control = _controlsLanguageData.ControlFindByKey("UserExistForName", 2, session.LanguageId);
                    throw control.CreateException(user.UserName);
                }

                user.CreationDate = DateTime.Now;
                user.UserCreationId = session.Id;
                user.UpdateDate = null;
                user.UserUpdateId = null;

                Guid id = _userAppData.InsertKey<Guid>(user);

                user.UserId = id;
                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UserApp UserAppUpdate(UserApp user, UserSession session)
        {
            try
            {
                if (_userAppData.ExistUserByUserName(user))
                {
                    var control = _controlsLanguageData.ControlFindByKey("UserExistForName", 2, session.LanguageId);
                    throw control.CreateException(user.UserName);
                }

                var oldUser = _userAppData.Get(user.UserId);

                oldUser.UpdateDate = DateTime.Now;
                oldUser.UserUpdateId = session.Id;
                oldUser.UserDocument = user.UserDocument;
                oldUser.UserDocumentTypeId = user.UserDocumentTypeId;
                oldUser.UserEmail = user.UserEmail;
                oldUser.UserFirstName = user.UserFirstName;
                oldUser.UserLastName = user.UserLastName;

                _userAppData.Update(oldUser);

                return oldUser;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Consulta un usuario en la base de datos por id
        /// </summary>
        /// <param name="guid">id del usuario</param>
        /// <returns>UserApp</returns>
        public UserApp UsertFinById(Guid guid)
        {
            try
            {
                return _userAppData.Get(guid);
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
                    if (_userAppData != null)
                        _userAppData.Dispose();
                }

                // TODO: libere los recursos no administrados (objetos no administrados) y reemplace el siguiente finalizador.
                // TODO: configure los campos grandes en nulos.

                disposedValue = true;
            }
        }

        // TODO: reemplace un finalizador solo si el anterior Dispose(bool disposing) tiene código para liberar los recursos no administrados.
        // ~UserBusiness() {
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
    /// Clase de negocio para la tabla User
    /// </summary>
    public interface IUserServices : IDisposable
    {
        /// <summary>
        /// Consulta un usuario en la base de datos por numero de documento
        /// </summary>
        /// <param name="document">numero de documento</param>
        /// <returns>UserApp</returns>
        UserApp UserFindByDocument(string document);

        /// <summary>
        /// Consulta un usuario en la base de datos por correo electronico
        /// </summary>
        /// <param name="email">correo electronico</param>
        /// <returns>UserApp</returns>
        UserApp UserFindByEmail(string email);

        /// <summary>
        /// Consulta un usuario por nombre de usuario
        /// </summary>
        /// <param name="userName">nombre de usuario</param>
        /// <returns>UserApp</returns>
        UserApp UserFindByUser(string userName);

        /// <summary>
        /// Inserta un nuevo usuario en la base de datos
        /// </summary>
        /// <param name="user">usuario a guardar</param>
        /// <param name="session">sesion del usuario</param>
        /// <returns>UserApp</returns>
        UserApp UserAppInsert(UserApp user, UserSession session);

        /// <summary>
        /// Actualiza un usuario por id en la base de datos
        /// </summary>
        /// <param name="user">usuario a modificar</param>
        /// <param name="session">sesion del usuario</param>
        /// <returns>UserApp</returns>
        UserApp UserAppUpdate(UserApp user, UserSession session);

        /// <summary>
        /// Consulta un usuario en la base de datos por id
        /// </summary>
        /// <param name="guid">id del usuario</param>
        /// <returns>UserApp</returns>
        UserApp UsertFinById(Guid guid);
    }
}