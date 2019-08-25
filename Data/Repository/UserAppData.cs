using Entity;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository
{
    /// <summary>
    /// Acceso a datos a la tabla UserApp
    /// </summary>
    public class UserAppData : DataRepository<UserApp>, IDisposable, IUserAppData
    {
        public UserAppData() : base()
        {
        }

        public UserAppData(IConnection connection) : base(connection)
        {
        }

        /// <summary>
        /// Verifica si existe un usuario por nombre de usuario
        /// </summary>
        /// <param name="user">usuario</param>
        /// <param name="transaction">transaccion sql server</param>
        /// <returns></returns>

        public async Task<bool> ExistUserByUserName(UserApp user, IDbTransaction transaction = null)
        {
            try
            {
                int count = 0;
                if (user.UserId == Guid.Empty)
                    count = await CountAsync("WHERE UserName =@user", new { user = user.UserName }, transaction: transaction);
                else
                    count = await CountAsync("WHERE UserName = @user AND UserId <> @id", new
                    {
                        user = user.UserName,
                        id = user.UserId
                    }, transaction: transaction);

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Consulta un usuario en la base de datos por nombre de usuario
        /// </summary>
        /// <param name="userName">nombre de usuario</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>UserApp</returns>
        public async Task<UserApp> UserFindByUser(string userName, IDbTransaction transaction = null)
        {
            try
            {
                var user = await GetListAsync("WHERE UserName = @UserName", new { UserName = userName }, transaction: transaction);
                return user.FirstOrDefault();
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
        /// <param name="transaction">transaccion sql</param>
        /// <returns>UserApp</returns>
        public async Task<UserApp> UserFindByDocument(string document, IDbTransaction transaction = null)
        {
            try
            {
                var user = await GetListAsync("WHERE UserDocument = @UserDocument", new { UserDocument = document }, transaction: transaction);
                return user.FirstOrDefault();
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
        /// <param name="transaction">transaccion sql</param>
        /// <returns>UserApp</returns>
        public async Task<UserApp> UserFindByEmail(string email, IDbTransaction transaction = null)
        {
            try
            {
                var user = await GetListAsync("WHERE UserEmail = @UserEmail", new { UserEmail = email }, transaction: transaction);
                return user.FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    /// <summary>
    /// Acceso a datos a la tabla UserApp
    /// </summary>
    public interface IUserAppData : IDataRepository<UserApp>, IDisposable
    {
        /// <summary>
        /// Consulta un usuario en la base de datos por nombre de usuario
        /// </summary>
        /// <param name="userName">nombre de usuario</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>UserApp</returns>
        Task<UserApp> UserFindByUser(string userName, IDbTransaction transaction = null);

        /// <summary>
        /// Consulta un usuario en la base de datos por numero de documento
        /// </summary>
        /// <param name="document">numero de documento</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>UserApp</returns>
        Task<UserApp> UserFindByDocument(string document, IDbTransaction transaction = null);

        /// <summary>
        /// Consulta un usuario en la base de datos por correo electronico
        /// </summary>
        /// <param name="email">correo electronico</param>
        /// <param name="transaction">transaccion sql</param>
        /// <returns>UserApp</returns>
        Task<UserApp> UserFindByEmail(string email, IDbTransaction transaction = null);

        /// <summary>
        /// Verifica si existe un usuario por nombre de usuario
        /// </summary>
        /// <param name="user">usuario</param>
        /// <param name="transaction">transaccion sql server</param>
        /// <returns></returns>

        Task<bool> ExistUserByUserName(UserApp user, IDbTransaction transaction = null);
    }
}