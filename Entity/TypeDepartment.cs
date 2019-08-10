using System;

namespace Entity
{
    public class TypeDepartment
    {
        public int TypeDepartmentId { get; set; }
        public string TypeDepartmentName { get; set; }
        public bool TypeDepartmentActive { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid UserCreationId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Guid? UserUpdateId { get; set; }
    }
}