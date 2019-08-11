using Dapper;
using System;

namespace Entity
{
    [Table("CurrentSession")]
    public class CurrentSession
    {
        [Key]
        [Column("SessionId")]
        public Guid SessionId { get; set; }

        [Column("UserId")]
        public Guid UserId { get; set; }

        [Column("Active")]
        public bool Active { get; set; }

        [Column("CreationDate")]
        public DateTime CreationDate { get; set; }

        [Column("DateClosesSesion")]
        public DateTime? DateClosesSesion { get; set; }
    }
}