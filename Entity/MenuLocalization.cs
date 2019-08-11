using Dapper;

namespace Entity
{
    [Table("MenuLocalization")]
    public class MenuLocalization
    {
        [Key]
        [Column("MenuLocalizationId")]
        public int MenuLocalizationId { get; set; }

        [Column("MenuLocalizationName")]
        public string MenuLocalizationName { get; set; }
    }
}