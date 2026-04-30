using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domian_login.entities
{
    public class Auditoria
    {
        public int Id { get; private set; }
        public Usuario Usuario { get; private set; }
        public int UsuarioId { get; private set; }

        public string Accion { get; private set; }
        public string Modulo { get; private set; }

        public DateTime Fecha { get; private set; }

        public Auditoria(int usuarioId, string accion, string modulo)
        {
            UsuarioId = usuarioId;
            Accion = accion;
            Modulo = modulo;
            Fecha = DateTime.UtcNow;
        }
        private Auditoria() { }
    }
}
