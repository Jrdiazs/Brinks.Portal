using Entity;
using System;

namespace Data.Repository
{
    /// <summary>
    /// Acceso a datos a la tabla TypeDepartment
    /// </summary>
    public class TypeDepartmentData : DataRepository<TypeDepartment>, IDisposable, ITypeDepartmentData
    {
        public TypeDepartmentData()
        {
        }

        public TypeDepartmentData(IConnection connection) : base(connection)
        {
        }
    }

    /// <summary>
    /// Acceso a datos a la tabla TypeDepartment
    /// </summary>
    public interface ITypeDepartmentData : IDataRepository<TypeDepartment>, IDisposable { }
}