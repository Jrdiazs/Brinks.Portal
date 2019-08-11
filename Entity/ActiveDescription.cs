using Dapper;

namespace Entity
{
    [Table("ActiveDescription")]
    public class ActiveDescription
    {
        [Key]
        [Column("ActiveId")]
        public short ActiveId { get; set; }

        [Column("ActiveId")]
        public string ActiveName { get; set; }
    }
}