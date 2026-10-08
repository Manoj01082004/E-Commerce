using System;
using System.Collections.Generic;
using System.Text;

namespace E_CommerceDTO.DTO.UserDTO_s
{
    public  class UserLoginResponseDTO
    {
        public required string Token { get; set; }
        public UserDTO? User { get; set; }
    }
}
