using Entity;
using System;

namespace Data.Repository
{
    /// <summary>
    /// Acceso a datos de la tabla CurrentSession
    /// </summary>
    public class SessionData : DataRepository<CurrentSession>, ISessionData, IDisposable
    {
        public SessionData() : base()
        {
        }

        public SessionData(IConnection connection) : base(connection)
        {
        }
    }

    /// <summary>
    /// Acceso a datos de la tabla CurrentSession
    /// </summary>
    public interface ISessionData : IDataRepository<CurrentSession>, IDisposable { }
}