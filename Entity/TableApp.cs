using Dapper;
using System;

namespace Entity
{
    [Table("TableApp")]
    public class TableApp
    {
        [Key]
        [Column("TableId")]
        public int TableId { get; set; }

        [Column("TableName")]
        public string TableName { get; set; }

        [Column("TableIdName")]
        public string TableIdName { get; set; }

        [Column("ConvertName")]
        public string ConvertName { get; set; }

        [Column("ViewName")]
        public string ViewName { get; set; }

        [Column("DescriptionName")]
        public string DescriptionName { get; set; }

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