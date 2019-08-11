using Dapper;
using System;

namespace Entity
{
    [Table("Cities")]
    public class Cities
    {
        [Key]
        [Column("CityId")]
        public int CityId { get; set; }

        [Column("DepartmentId")]
        public int DepartmentId { get; set; }

        [Column("CityName")]
        public string CityName { get; set; }

        [Column("CityNameShort")]
        public string CityNameShort { get; set; }

        [Column("CityCode")]
        public string CityCode { get; set; }

        [Column("CityActive")]
        public bool CityActive { get; set; }

        [Column("CreationDate")]
        public DateTime CreationDate { get; set; }

        [Column("UserCreationId")]
        public Guid UserCreationId { get; set; }

        [Column("UpdateDate")]
        public DateTime? UpdateDate { get; set; }

        [Column("UserUpdateId")]
        public Guid? UserUpdateId { get; set; }

        [NotMapped]
        public Department Department { get; set; }
    }
}