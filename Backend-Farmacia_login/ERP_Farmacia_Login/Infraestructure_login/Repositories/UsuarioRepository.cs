using Domian_login.entities;
using Infraestructure_login.Data;
using Infraestructure_login.Data.Infraestructure_login.Data;
using Infraestructure_login.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure_login.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Guardar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public Usuario ObtenerPorEmail(string email)
        {
            return _context.Usuarios
            .Include(u => u.Rol)
            .FirstOrDefault(u => u.Email == email);
        }
    }
}
