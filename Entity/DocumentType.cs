using Dapper;
using System;

namespace Entity
{
    [Table("DocumentType")]
    public class DocumentType
    {
        [Key]
        [Column("DocumentTypeId")]
        public int DocumentTypeId { get; set; }

        [Column("DocumentName")]
        public string DocumentName { get; set; }

        [Column("DocumentShortName")]
        public string DocumentShortName { get; set; }

        [Column("DocumentTypeActive")]
        public bool DocumentTypeActive { get; set; }

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