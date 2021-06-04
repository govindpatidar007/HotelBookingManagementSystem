using Microsoft.AspNetCore.Identity;

namespace HBMSMVC.Areas.Identity.Pages.Account
{

    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }


}