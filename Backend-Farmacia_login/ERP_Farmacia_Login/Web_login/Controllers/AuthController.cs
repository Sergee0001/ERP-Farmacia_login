using Infraestructure_login.DTOs;
using Infraestructure_login.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Web_login.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly LoginUsuario _loginUsuario;

        public AuthController(LoginUsuario loginUsuario)
        {
            _loginUsuario = loginUsuario;
        }

        // 🔴 LOGIN REAL (POST)
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestDto request)
        {
            try
            {
                var result = _loginUsuario.Ejecutar(request.Email, request.Password);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // 🟢 SOLO PARA PROBAR EN NAVEGADOR (GET)
        [HttpGet("login")]
        public IActionResult LoginTest(string email, string password)
        {
            try
            {
                var result = _loginUsuario.Ejecutar(email, password);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
