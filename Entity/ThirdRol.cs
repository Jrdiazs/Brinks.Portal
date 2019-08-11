using Dapper;
using System;

namespace Entity
{
    [Table("ThirdRol")]
    public class ThirdRol
    {
        [Key]
        [Column("ThirdRolId")]
        public Guid ThirdRolId { get; set; }

        [Column("RolId")]
        public Guid RolId { get; set; }

        [Column("ThirdId")]
        public Guid ThirdId { get; set; }

        [Column("ThirdRolActive")]
        public bool ThirdRolActive { get; set; }

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