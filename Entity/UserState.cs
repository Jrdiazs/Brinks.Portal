using Dapper;
using System;

namespace Entity
{
    [Table("UserState")]
    public class UserState
    {
        [Key]
        [Column("UserStateId")]
        public int UserStateId { get; set; }

        [Column("UserStateName")]
        public string UserStateName { get; set; }

        [Column("UserStateShortName")]
        public string UserStateShortName { get; set; }

        [Column("UserStateActive")]
        public bool UserStateActive { get; set; }

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