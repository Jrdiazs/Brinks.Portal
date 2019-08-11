using Entity;
using System;

namespace Data.Repository
{
    /// <summary>
    /// Acceso a datos de la tabla UserState
    /// </summary>
    public class UserStateData : DataRepository<UserState>, IDisposable, IUserStateData
    {
        public UserStateData()
        {
        }

        public UserStateData(IConnection connection) : base(connection)
        {
        }
    }

    /// <summary>
    /// Acceso a datos de la tabla UserState
    /// </summary>
    public interface IUserStateData : IDataRepository<UserState>, IDisposable
    {
    }
}