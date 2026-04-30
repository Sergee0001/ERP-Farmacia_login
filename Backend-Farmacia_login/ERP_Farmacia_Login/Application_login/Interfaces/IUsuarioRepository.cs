using Domian_login.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure_login.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario ObtenerPorEmail(string email);
        void Guardar(Usuario usuario);
    }
}
