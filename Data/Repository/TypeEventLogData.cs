using Entity;
using System;

namespace Data.Repository
{
    /// <summary>
    /// Acceso a datos a la tabla TypeEventLog
    /// </summary>
    public class TypeEventLogData : DataRepository<TypeEventLog>, IDisposable, ITypeEventLogData
    {
        public TypeEventLogData()
        {
        }

        public TypeEventLogData(IConnection connection) : base(connection)
        {
        }
    }

    /// <summary>
    /// Acceso a datos a la tabla TypeEventLog
    /// </summary>
    public interface ITypeEventLogData : IDataRepository<TypeEventLog>, IDisposable
    {
    }
}