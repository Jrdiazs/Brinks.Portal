using System;

namespace Entity
{
    public class Cities
    {
        public int CityId { get; set; }
        public int DepartmentId { get; set; }
        public string CityName { get; set; }
        public string CityNameShort { get; set; }
        public string CityCode { get; set; }
        public bool CityActive { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid UserCreationId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Guid? UserUpdateId { get; set; }
    }
}