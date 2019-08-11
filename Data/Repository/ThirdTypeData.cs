using Entity;
using System;

namespace Data.Repository
{
    /// <summary>
    /// Acceso a datos a la tabla ThirdType
    /// </summary>
    public class ThirdTypeData : DataRepository<ThirdType>, IDisposable, IThirdTypeData
    {
        public ThirdTypeData()
        {
        }

        public ThirdTypeData(IConnection connection) : base(connection)
        {
        }
    }

    /// <summary>
    /// Acceso a datos a la tabla ThirdType
    /// </summary>
    public interface IThirdTypeData : IDataRepository<ThirdType>, IDisposable { }
}