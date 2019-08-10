using Dapper;
using System;

namespace Entity
{
    [Table("Third")]
    public class Third
    {
        [Key]
        [Column("ThirdId")]
        public Guid ThirdId { get; set; }

        [Column("ThirdDocument")]
        public string ThirdDocument { get; set; }

        [Column("ThirdDocumentTypeId")]
        public int ThirdDocumentTypeId { get; set; }

        [Column("ThirdName")]
        public string ThirdName { get; set; }

        [Column("ThirdTypeId")]
        public int ThirdTypeId { get; set; }

        [Column("ThirdAlias")]
        public string ThirdAlias { get; set; }

        [Column("ThirdActive")]
        public bool ThirdActive { get; set; }

        [Column("ThirdPhone")]
        public string ThirdPhone { get; set; }

        [Column("ThirdAddress")]
        public string ThirdAddress { get; set; }

        [Column("ThirdMail")]
        public string ThirdMail { get; set; }

        [Column("CreationDate")]
        public DateTime CreationDate { get; set; }

        [Column("UserCreationId")]
        public Guid UserCreationId { get; set; }

        [Column("UpdateDate")]
        public DateTime? UpdateDate { get; set; }

        [Column("UserUpdateId")]
        public Guid? UserUpdateId { get; set; }

        [NotMapped]
        public DocumentType Document { get; set; }

        [NotMapped]
        public ThirdType ThirdType { get; set; }
    }
}