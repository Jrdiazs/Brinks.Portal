using System;

namespace Entity
{
    /// <summary>
    /// Modelo que representa una vista entre la tabla PolicyGlobal y PolicyThird
    /// </summary>
    public class PolicyView
    {
        public Guid PolicyId { get; set; }

        public Guid? ThirdId { get; set; }

        public bool IsPwExpired { get; set; }

        public int? PwChangeReminder { get; set; }

        public int? NumberOfDaysExpirePw { get; set; }

        public int NumberOfAttemps { get; set; }

        public int PwMaxLength { get; set; }

        public int PwMinLength { get; set; }

        public bool PwContainsCharacters { get; set; }

        public bool PwContainsNumbers { get; set; }

        public bool PwContainsOneLetterUpper { get; set; }

        public bool PwContainsOneLowerUpper { get; set; }

        public bool InsertLogUser { get; set; }

        public int? NumberPasswordHistory { get; set; }

        public Third Third { get; set; }
    }
}