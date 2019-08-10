using Dapper;
using System;

namespace Entity
{
    [Table("ParametersApp")]
    public class ParametersApp
    {
        [Key]
        [Column("ParameterId")]
        public int ParameterId { get; set; }

        [Column("ParameterKey")]
        public string ParameterKey { get; set; }

        [Column("ParameterDescription")]
        public string ParameterDescription { get; set; }

        [Column("ParameterLocked")]
        public bool ParameterLocked { get; set; }

        [Column("ParameterInt")]
        public int? ParameterInt { get; set; }

        [Column("ParameterDatetime")]
        public DateTime? ParameterDatetime { get; set; }

        [Column("ParameterBigInt")]
        public long? ParameterBigInt { get; set; }

        [Column("ParameterGuid")]
        public Guid? ParameterGuid { get; set; }

        [Column("ParameterDecimal")]
        public decimal? ParameterDecimal { get; set; }

        [Column("ParameterString")]
        public string ParameterString { get; set; }

        [Column("ParameterArray")]
        public byte[] ParameterArray { get; set; }

        [Column("CreationDate")]
        public DateTime CreationDate { get; set; }

        [Column("UserCreationId")]
        public Guid UserCreationId { get; set; }

        [Column("UpdateDate")]
        public DateTime? UpdateDate { get; set; }

        [Column("UserUpdateId")]
        public Guid? UserUpdateId { get; set; }

        [Column("ParameterBoolean")]
        public bool ParameterBoolean { get; set; }
    }
}