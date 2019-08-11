using Dapper;
using System;

namespace Entity
{
    [Table("Country")]
    public class Country
    {
        [Key]
        [Column("CountryId")]
        public int CountryId { get; set; }

        [Column("CountryName")]
        public string CountryName { get; set; }

        [Column("CountryNameShort")]
        public string CountryNameShort { get; set; }

        [Column("CountryIdCode")]
        public string CountryIdCode { get; set; }

        [Column("CountryCode")]
        public string CountryCode { get; set; }

        [Column("CountryIcon")]
        public string CountryIcon { get; set; }

        [Column("TypeDepartmentId")]
        public int? TypeDepartmentId { get; set; }

        [Column("CountryActive")]
        public bool CountryActive { get; set; }

        [Column("CreationDate")]
        public DateTime CreationDate { get; set; }

        [Column("UserCreationId")]
        public Guid UserCreationId { get; set; }

        [Column("UpdateDate")]
        public DateTime? UpdateDate { get; set; }

        [Column("UserUpdateId")]
        public Guid? UserUpdateId { get; set; }

        [NotMapped]
        public TypeDepartment TypeDepartment { get; set; }
    }
}