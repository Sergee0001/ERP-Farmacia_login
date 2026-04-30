using Domian_login.entities;
using Infraestructure_login.Data;
using Infraestructure_login.Data.Infraestructure_login.Data;
using Infraestructure_login.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure_login.Repositories
{
    public class AuditoriaRepository : IAuditoriaRepository
    {
        private readonly AppDbContext _context;

        public AuditoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Registrar(Auditoria auditoria)
        {
            _context.Auditorias.Add(auditoria);
            _context.SaveChanges();
        }
    }
}
