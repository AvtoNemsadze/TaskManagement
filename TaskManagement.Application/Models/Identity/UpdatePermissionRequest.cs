using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Models.Identity
{
    public class UpdatePermissionRequest
    {
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; } = null!;
    }
}
