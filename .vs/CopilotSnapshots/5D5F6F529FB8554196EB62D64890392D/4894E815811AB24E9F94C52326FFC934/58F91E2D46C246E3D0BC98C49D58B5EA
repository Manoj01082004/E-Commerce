using E_CommerceDTO.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace E_CommerceDTO.DTO.UserDTO_s
{
    public class UserRegisterDTO
    {
        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }

        [Required]
        [MaxLength(256)]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [MaxLength(255)]
        public required string PasswordHash { get; set; }
    }
}
