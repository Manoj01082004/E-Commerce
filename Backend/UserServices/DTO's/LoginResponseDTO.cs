using UserServices.DTOs;

namespace UserServices.DTO_s
{
        public class LoginResponseDTO
        {
            public required string AccessToken { get; set; }

            public required UserDTO User { get; set; }
        }
    
}
