using Microsoft.AspNetCore.Identity;


namespace TaskManagement.Identity.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public ICollection<ApplicationRole> Roles { get; set; } = new List<ApplicationRole>();
    }

    public class ApplicationRole : IdentityRole<int>
    {

    }
}
