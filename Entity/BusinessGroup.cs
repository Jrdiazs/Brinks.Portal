using Dapper;
using System;

namespace Entity
{
    [Table("BusinessGroup")]
    public class BusinessGroup
    {
        [Key]
        [Column("BusinessGroupId")]
        public Guid BusinessGroupId { get; set; }

        [Column("ThirdIdParent")]
        public Guid ThirdIdParent { get; set; }

        [Column("ThirdIdChildren")]
        public Guid ThirdIdChildren { get; set; }

        [Column("BusinessGroupActive")]
        public bool BusinessGroupActive { get; set; }

        [Column("CreationDate")]
        public DateTime CreationDate { get; set; }

        [Column("UserCreationId")]
        public Guid UserCreationId { get; set; }

        [Column("UpdateDate")]
        public DateTime? UpdateDate { get; set; }

        [Column("UserUpdateId")]
        public Guid? UserUpdateId { get; set; }

        [NotMapped]
        public Third ThirdParent { get; set; }

        [NotMapped]
        public Third ThirdCildren { get; set; }
    }
}