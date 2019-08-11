using Dapper;
using System;

namespace Entity
{
    [Table("MessageSystemApp")]
    public class MessageSystemApp
    {
        [Key]
        [Column("MessageSystemId")]
        public Guid MessageSystemId { get; set; }

        [Column("MessageCode")]
        public long MessageCode { get; set; }

        [Column("MessageDescription")]
        public string MessageDescription { get; set; }

        [Column("LanguageId")]
        public int LanguageId { get; set; }

        [Column("MessageActive")]
        public bool MessageActive { get; set; }

        [Column("CreationDate")]
        public DateTime CreationDate { get; set; }

        [Column("UserCreationId")]
        public Guid UserCreationId { get; set; }

        [Column("UpdateDate")]
        public DateTime? UpdateDate { get; set; }

        [Column("UserUpdateId")]
        public Guid? UserUpdateId { get; set; }

        [NotMapped]
        public LanguageApp Language { get; set; }
    }
}