using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domian_login.entities
{       
    public class Rol
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }

        public List<Usuario> Usuarios { get; private set; } = new();

        public Rol(string nombre)
        {
            Nombre = nombre;
        }
    }
}
