using Dapper;
using System;

namespace Entity
{
    [Table("ThirdType")]
    public class ThirdType
    {
        [Key]
        [Column("ThirdTypeId")]
        public int ThirdTypeId { get; set; }

        [Column("ThirdTypeName")]
        public string ThirdTypeName { get; set; }

        [Column("CreationDate")]
        public DateTime CreationDate { get; set; }

        [Column("UserCreationId")]
        public Guid UserCreationId { get; set; }

        [Column("UpdateDate")]
        public DateTime? UpdateDate { get; set; }

        [Column("UserUpdateId")]
        public Guid? UserUpdateId { get; set; }
    }
}