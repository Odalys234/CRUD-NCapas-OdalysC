using C.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace C.AccesoDatos
{
    public class PersonasCDAL
    {
        public static async Task<List<PersonaC>> GetAll()
        {
            using (var dbContext = new ComunDB())
            {
                return await dbContext.PersonaC.ToListAsync();
            }
        }

        public static async Task<PersonaC> GetById(PersonaC pPersonaC)
        {
            using (var dbContext = new ComunDB())
            {
                return await dbContext.PersonaC.FirstOrDefaultAsync(s => s.Id == pPersonaC.Id);
            }
        }

        public static async Task<int> Create(PersonaC pPersonaC)
        {
            using (var dbContext = new ComunDB())
            {
                dbContext.PersonaC.Add(pPersonaC);
                return await dbContext.SaveChangesAsync();
            }
        }

        public static async Task<int> Update(PersonaC pPersonaC)
        {
            using (var dbContext = new ComunDB())
            {
                var personac = await dbContext.PersonaC.FirstOrDefaultAsync(r => r.Id == pPersonaC.Id);
                personac.NombreC = pPersonaC.NombreC;
                personac.ApellidoC = pPersonaC.ApellidoC;
                personac.FechaNacimientoC = pPersonaC.FechaNacimientoC;
                personac.SueldoC = pPersonaC.SueldoC;
                personac.EstatusC = pPersonaC.EstatusC;
                personac.ComentarioC = pPersonaC.ComentarioC;
                return await dbContext.SaveChangesAsync();
            }
        }

        public static async Task<int> Delete(PersonaC pPersonaC)
        {
            using (var dbContext = new ComunDB())
            {
                var personac = await dbContext.PersonaC.FirstOrDefaultAsync(r => r.Id == pPersonaC.Id);
                dbContext.PersonaC.Remove(personac);
                return await dbContext.SaveChangesAsync();
            }
        }

        public static async Task<PersonaC> Add(PersonaC pPersonaC)
        {
            using (var dbContext = new ComunDB())
            {
                dbContext.PersonaC.Add(pPersonaC);
                await dbContext.SaveChangesAsync();
                return pPersonaC;
            }
        }
    }
}

