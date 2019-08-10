using Dapper;
using System;

namespace Entity
{
    [Table("UserApp")]
    public class UserApp
    {
        [Key]
        [Column("UserId")]
        public Guid UserId { get; set; }

        [Column("UserDocument")]
        public string UserDocument { get; set; }

        [Column("UserDocumentTypeId")]
        public int UserDocumentTypeId { get; set; }

        [Column("UserName")]
        public string UserName { get; set; }

        [Column("UserFirstName")]
        public string UserFirstName { get; set; }

        [Column("UserLastName")]
        public string UserLastName { get; set; }

        [Column("UserEmail")]
        public string UserEmail { get; set; }

        [Column("UserStateId")]
        public int UserStateId { get; set; }

        [Column("UserChangePw")]
        public bool UserChangePw { get; set; }

        [Column("UserLastPasswordChange")]
        public DateTime UserLastPasswordChange { get; set; }

        [Column("UserRestorePw")]
        public bool? UserRestorePw { get; set; }

        [Column("UserNumberOfAttemps")]
        public int UserNumberOfAttemps { get; set; }

        [Column("UserLastDateEntry")]
        public DateTime? UserLastDateEntry { get; set; }

        [Column("UserPw")]
        public string UserPw { get; set; }

        [Column("LanguageId")]
        public int? LanguageId { get; set; }

        [Column("PolicyId")]
        public Guid? PolicyId { get; set; }

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