using Dapper;
using System;

namespace Entity
{
    [Table("UserRol")]
    public class UserRol
    {
        [Key]
        [Column("UserRolId")]
        public Guid UserRolId { get; set; }

        [Column("UserId")]
        public Guid UserId { get; set; }

        [Column("RolId")]
        public Guid RolId { get; set; }

        [Column("UserRolActive")]
        public bool UserRolActive { get; set; }

        [Column("CreationDate")]
        public DateTime CreationDate { get; set; }

        [Column("UserCreationId")]
        public Guid UserCreationId { get; set; }

        [Column("UpdateDate")]
        public DateTime? UpdateDate { get; set; }

        [Column("UserUpdateId")]
        public Guid? UserUpdateId { get; set; }

        [NotMapped]
        public UserApp User { get; set; }

        [NotMapped]
        public Rol Rol { get; set; }
    }
}