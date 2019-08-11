using Dapper;
using System;

namespace Entity
{
    [Table("TypeEventLog")]
    public class TypeEventLog
    {
        [Key]
        [Column("TypeEventLogId")]
        public int TypeEventLogId { get; set; }

        [Column("TypeEventName")]
        public string TypeEventName { get; set; }

        [Column("CreationDate")]
        public DateTime? CreationDate { get; set; }

        [Column("UserCreationId")]
        public Guid? UserCreationId { get; set; }

        [Column("UpdateDate")]
        public DateTime? UpdateDate { get; set; }

        [Column("UserUpdateId")]
        public Guid? UserUpdateId { get; set; }
    }
}