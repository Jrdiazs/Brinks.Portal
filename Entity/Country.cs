using System;

namespace Entity
{
    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryNameShort { get; set; }
        public string CountryIdCode { get; set; }
        public string CountryCode { get; set; }
        public string CountryIcon { get; set; }
        public int? TypeDepartmentId { get; set; }
        public bool CountryActive { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid UserCreationId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Guid? UserUpdateId { get; set; }
    }
}