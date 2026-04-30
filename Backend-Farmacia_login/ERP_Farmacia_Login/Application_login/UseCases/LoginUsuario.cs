using Application_login.DTOs;
using Domian_login.entities;
using Infraestructure_login.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure_login.UseCases
{
    public class LoginUsuario
    {
        private readonly IUsuarioRepository _usuarioRepo;
        private readonly IAuditoriaRepository _auditoriaRepo;

        public LoginUsuario(IUsuarioRepository usuarioRepo,
                            IAuditoriaRepository auditoriaRepo)
        {
            _usuarioRepo = usuarioRepo;
            _auditoriaRepo = auditoriaRepo;
        }

        public LoginResponseDto Ejecutar(string email, string password)
        {
            var usuario = _usuarioRepo.ObtenerPorEmail(email);

            if (usuario == null)
                throw new Exception("Usuario no existe");

            if (!usuario.Activo)
                throw new Exception("Usuario inactivo");

            if (usuario.PasswordHash != password)
                throw new Exception("Contraseña incorrecta");

            var auditoria = new Auditoria(
                usuario.Id,
                "LOGIN",
                "SEGURIDAD"
            );

            _auditoriaRepo.Registrar(auditoria);

            return new LoginResponseDto
            {
                Nombre = usuario.Nombre,
                Email = usuario.Email,
                Rol = usuario.Rol.Nombre
            };
        }
    }
}
