using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using C.EntidadesNegocio;
using C.AccesoDatos;
namespace C.LogicaNegocio
{
    public class PersonasCBL
    {
        public static async Task<PersonaC>GetById(PersonaC pPersonaC)
        {
            return await PersonasCDAL.GetById(pPersonaC);
        }
        public static async Task<int> Create(PersonaC pPersonaC)
        {
            return await PersonasCDAL.Create(pPersonaC);
        }
        public static async Task<int> Update(PersonaC pPersonaC)
        {
            return await PersonasCDAL.Update(pPersonaC);
        }

        public static async Task<int> Delete(PersonaC pPersonaC)
        {
            return await PersonasCDAL.Delete(pPersonaC);

        }
        public static async Task<List<PersonaC>> GetAll()
        {
            return await PersonasCDAL.GetAll();
        }
        public static async Task<PersonaC> Add(PersonaC pPersonaC)
        {
            return await PersonasCDAL.Add(pPersonaC);
        }
    }
}
