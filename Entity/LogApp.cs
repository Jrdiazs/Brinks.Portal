using Dapper;
using System;

namespace Entity
{
    [Table("LogApp")]
    public class LogApp
    {
        [Key]
        [Column("Id")]
        public long Id { get; set; }

        [Column("Date")]
        public DateTime? Date { get; set; }

        [Column("Thread")]
        public string Thread { get; set; }

        [Column("Level")]
        public string Level { get; set; }

        [Column("Logger")]
        public string Logger { get; set; }

        [Column("Message")]
        public string Message { get; set; }

        [Column("Exception")]
        public string Exception { get; set; }
    }
}