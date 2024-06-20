using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.BLL.Services.Concrete
{
    public static class LoggedInUserExtension
    {
        //Kullanıcı Id int tipinde olduğu için metot int döndürecek. return'dan sonrası string normalde onu da int'te çevirdik.
        public static int GetLoggedInUserId(this ClaimsPrincipal principal) 
        {
            return Convert.ToInt32(principal.FindFirstValue(ClaimTypes.NameIdentifier));
        }

        public static string GetLoggedInEmail(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue(ClaimTypes.Email);
        }
    }
}
