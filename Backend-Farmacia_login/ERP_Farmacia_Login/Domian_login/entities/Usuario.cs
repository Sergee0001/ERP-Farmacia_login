using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domian_login.entities
{
    public class Usuario
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public bool Activo { get; private set; }
        public Rol Rol { get; private set; }
        public int RolId { get; private set; }
        public List<Auditoria> Auditorias { get; private set; } = new();
        // Constructor principal
        public Usuario(string nombre, string email, string passwordHash, int rolId)
        {
            Nombre = nombre;
            Email = email;
            PasswordHash = passwordHash;
            RolId = rolId;
            Activo = true;
        }

        // Constructor vacío para EF (opcional)
        private Usuario() { }

        public void Desactivar()
        {
            Activo = false;
        }
    }
}
