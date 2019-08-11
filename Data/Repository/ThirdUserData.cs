using Entity;
using System;

namespace Data.Repository
{
    /// <summary>
    /// Acceso a datos a la tabla ThirdUser
    /// </summary>
    public class ThirdUserData : DataRepository<ThirdUser>, IDisposable, IThirdUserData
    {
        public ThirdUserData()
        {
        }

        public ThirdUserData(IConnection connection) : base(connection)
        {
        }
    }

    /// <summary>
    /// Acceso a datos a la tabla ThirdUser
    /// </summary>
    public interface IThirdUserData : IDataRepository<ThirdUser>, IDisposable { }
}