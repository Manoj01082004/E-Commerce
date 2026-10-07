using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace E_CommerceDTO.DTO.UserDTO_s
{
    public class UserLoginDTO
    {
        [Required]
        [MaxLength(256)]
        public required string Email { get; set; }

        [Required]
        [MaxLength(255)]
        public required string PasswordHash { get; set; }
    }
}
