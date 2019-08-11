using Dapper;
using System;

namespace Entity
{
    [Table("UserPwHistory")]
    public class UserPwHistory
    {
        [Key]
        [Column("UserPwHistoryId")]
        public Guid UserPwHistoryId { get; set; }

        [Column("UserId")]
        public Guid UserId { get; set; }

        [Column("UserPw")]
        public string UserPw { get; set; }

        [Column("CreationDate")]
        public DateTime CreationDate { get; set; }

        [Column("UserCreationId")]
        public Guid UserCreationId { get; set; }
    }
}