using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class AdminValidate
    {
        static MyContext context = new MyContext();

        public static bool Login(string username, string password)
        {
            return context.Admins.Any(user =>
                user.Name.Equals(username, StringComparison.OrdinalIgnoreCase)
                && user.Password == password);
        }
    }
}