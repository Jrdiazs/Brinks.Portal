using System;

namespace Entity
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public int CountryId { get; set; }
        public string DepartmentName { get; set; }
        public bool DeparmentActive { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid UserCreationId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Guid? UserUpdateId { get; set; }
    }
}