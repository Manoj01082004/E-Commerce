using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using UserServices.Models;

namespace UserServices.DTOs
{
    public class UserDTO
    {
        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }

        [Required]
        [MaxLength(256)]
        public required string Email { get; set; }
        [Required]
        [MaxLength(20)]
        
        public string Role { get; set; } = Roles.Customer;
    }
}
