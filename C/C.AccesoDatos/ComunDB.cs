using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C.EntidadesNegocio;

namespace C.AccesoDatos
{
    public class ComunDB : DbContext
    {
        public DbSet<PersonaC> PersonaC { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-4TMNANE;Initial Catalog=CDB;Integrated Security=True;Trust Server Certificate=True");
        }
    }
}
