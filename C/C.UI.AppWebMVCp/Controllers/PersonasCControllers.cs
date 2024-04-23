using C.EntidadesNegocio;
using C.LogicaNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using System.Data;

namespace C.UI.AppWebMVCp.Controllers
{
    public class PersonasCControllers : Controller
    {
        // GET: PersonasCControllers
        public async Task<ActionResult> Index()
        {
            var personac = await PersonasCBL.GetAll();
            return View(personac);
        }

        // GET: PersonasCControllers/Details/5
        public async Task< ActionResult >Details(int id)
        {
            var personac = await PersonasCBL.GetById(new PersonaC { Id = id }); // Obtener personas por su Id
            if (personac == null)
            {
                return NotFound(); // Otra acción en caso de que personas no se encuentre
            }
            return View(personac); // Pasar personas como modelo a la vista Pasar personas como modelo a la vista
        }

        // GET: PersonasCControllers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonasCControllers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Create(PersonaC pPersonaC)
        {
            try
            {
                var result = PersonasCBL.Create(pPersonaC);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonasCControllers/Edit/5
        public async Task < ActionResult> Edit(int id)
        {
            var personasc = await PersonasCBL.GetById(new PersonaC { Id = id }); 
            if (personasc == null)
            {
                return NotFound(); 
            }
            return View(personasc);
           
        }

        // POST: PersonasCControllers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Edit(int id ,PersonaC pPersonaC)
        {

            try
            {
                var personascToUpdate = await PersonasCBL.GetById(new PersonaC { Id = id }); // Obtener personas por su Id
                if (personascToUpdate == null)
                {
                    return NotFound(); // Otra acción en caso de que personas no se encuentre
                }

                // Actualizar los datos personas con los datos del modelo recibido en el POST
                personascToUpdate.NombreC = pPersonaC.NombreC;
                personascToUpdate.ApellidoC = pPersonaC.ApellidoC;
                personascToUpdate.FechaNacimientoC = pPersonaC.FechaNacimientoC;
                personascToUpdate.SueldoC = pPersonaC.SueldoC;
                personascToUpdate.EstatusC = pPersonaC.EstatusC;
                personascToUpdate.ComentarioC = pPersonaC.ComentarioC;

                // Realizar la actualización en la base de datos
                var result = await PersonasCBL.Update(personascToUpdate);

                // Redireccionar al usuario a la página de índice después de la edición exitosa
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonasCControllers/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var personasc = await PersonasCBL.GetById(new PersonaC { Id = id }); 
            if (personasc == null)
            {
                return NotFound(); 
            }
            return View(personasc); 
        }

        // POST: PersonasCControllers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete( PersonaC pPersonaC)
        {
            try
            {
                var result = await PersonasCBL.Delete(pPersonaC);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
    