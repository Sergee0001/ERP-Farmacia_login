using Domian_login.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure_login.Interfaces
{
    public interface IAuditoriaRepository
    {
        void Registrar(Auditoria auditoria);

    }
}
