using Entity;
using System;

namespace Services
{
    public class BusinessBase
    {
        public UserSession UserSession { get; set; }

        public BusinessBase()
        {
            UserSession = new UserSession()
            {
                Id = Guid.Empty,
                DateOfAdmission = DateTime.MinValue,
                Ip = "localhost",
                LanguageId = 1,
                PoliceId = Guid.Empty
            };
        }

        public BusinessBase(UserSession userSession) => UserSession = userSession;
    }
}