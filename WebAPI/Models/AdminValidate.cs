using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class AdminValidate
    {
        static MyContext context = new MyContext();

        public static bool Login(string email, string password)
        {
            return context.Admins.Any(admin =>
                admin.Email.Equals(email, StringComparison.OrdinalIgnoreCase)
                && admin.Password == password);
        }
    }
}