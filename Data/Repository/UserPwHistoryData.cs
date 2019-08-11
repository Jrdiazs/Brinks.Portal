using Entity;
using System;

namespace Data.Repository
{
    /// <summary>
    /// Acceso a datos a la tabla UserPwHistory
    /// </summary>
    public class UserPwHistoryData : DataRepository<UserPwHistory>, IDisposable, IUserPwHistoryData
    {
        public UserPwHistoryData()
        {
        }

        public UserPwHistoryData(IConnection connection) : base(connection)
        {
        }
    }

    /// <summary>
    /// Acceso a datos a la tabla UserPwHistory
    /// </summary>
    public interface IUserPwHistoryData : IDataRepository<UserPwHistory>, IDisposable { }
}