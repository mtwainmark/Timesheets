using System.Collections.Generic;

namespace Timesheet.Api.Services
{
    public class AuthService
    {
        public AuthService()
        {
            Employees = new List<string>
            {
                "Иванов",
                "Петров",
                "Сидоров",
            };
        }

        public List<string> Employees { get; private set; }

        public bool Login(string lastName)
        {
            if (string.IsNullOrEmpty(lastName))
            {
                return false;
            }

            var isEmployeeExist = Employees.Contains(lastName);

            if (isEmployeeExist)
            {
                UserSession.Sessions.Add(lastName);
            }


            return isEmployeeExist;
        }
    }

    public static class UserSession
    {
        static UserSession()
        {
            Sessions = new HashSet<string>();
        }

        public static HashSet<string> Sessions { get; set; }
    }
}
