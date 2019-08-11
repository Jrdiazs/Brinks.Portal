using Entity;
using System;

namespace Data.Repository
{
    /// <summary>
    /// Acceso a datos a la tabla TypeRol
    /// </summary>
    public class TypeRolData : DataRepository<TypeRol>, IDisposable, ITypeRolData
    {
        public TypeRolData()
        {
        }

        public TypeRolData(IConnection connection) : base(connection)
        {
        }
    }

    /// <summary>
    /// Acceso a datos a la tabla TypeRol
    /// </summary>
    public interface ITypeRolData : IDataRepository<TypeRol>, IDisposable
    {
    }
}