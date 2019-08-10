using Dapper;
using System;

namespace Entity
{
    [Table("PolicyGlobalApp")]
    public class PolicyGlobalApp
    {
        [Key]
        [Column("PolicyId")]
        public Guid PolicyId { get; set; }

        [Column("IsPwExpired")]
        public bool IsPwExpired { get; set; }

        [Column("PwChangeReminder")]
        public int? PwChangeReminder { get; set; }

        [Column("NumberOfDaysExpirePw")]
        public int? NumberOfDaysExpirePw { get; set; }

        [Column("NumberOfAttemps")]
        public int NumberOfAttemps { get; set; }

        [Column("PwMaxLength")]
        public int PwMaxLength { get; set; }

        [Column("PwMinLength")]
        public int PwMinLength { get; set; }

        [Column("PwContainsCharacters")]
        public bool PwContainsCharacters { get; set; }

        [Column("PwContainsNumbers")]
        public bool PwContainsNumbers { get; set; }

        [Column("PwContainsOneLetterUpper")]
        public bool PwContainsOneLetterUpper { get; set; }

        [Column("PwContainsOneLowerUpper")]
        public bool PwContainsOneLowerUpper { get; set; }

        [Column("InsertLogUser")]
        public bool InsertLogUser { get; set; }

        [Column("NumberPasswordHistory")]
        public int? NumberPasswordHistory { get; set; }

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