using Dapper;
using System;

namespace Entity
{
    [Table("ThirdUser")]
    public class ThirdUser
    {
        [Key]
        [Column("ThirdUserId")]
        public Guid ThirdUserId { get; set; }

        [Column("UserId")]
        public Guid UserId { get; set; }

        [Column("ThirdId")]
        public Guid ThirdId { get; set; }

        [Column("ThirdUserActive")]
        public bool ThirdUserActive { get; set; }

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
        public Third Third { get; set; }
    }
}