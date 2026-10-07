using E_CommerceDTO.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace E_CommerceDTO.DTO.UserDTO_s
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
