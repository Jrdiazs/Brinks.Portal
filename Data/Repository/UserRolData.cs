using Entity;
using System;

namespace Data.Repository
{
    /// <summary>
    /// Acceso a datos a la tabla UserRol
    /// </summary>
    public class UserRolData : DataRepository<UserRol>, IDisposable, IUserRolData
    {
        public UserRolData()
        {
        }

        public UserRolData(IConnection connection) : base(connection)
        {
        }
    }

    /// <summary>
    /// Acceso a datos a la tabla UserRol
    /// </summary>
    public interface IUserRolData : IDataRepository<UserRol>, IDisposable
    {
    }
}