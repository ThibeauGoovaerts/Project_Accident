using Microsoft.AspNetCore.Identity;

namespace WebApplication4.Models {
    public class User : IdentityUser {
        public int PersonID { get; set; } = 1;
        public Person Person { get; set; } 
    }
}
