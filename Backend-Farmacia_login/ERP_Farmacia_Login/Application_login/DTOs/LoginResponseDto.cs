using System;
using System.Collections.Generic;
using System.Text;

namespace Application_login.DTOs
{
    public class LoginResponseDto
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }
    }
}
