using MVCsem10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCsem10.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        public ActionResult Index()
        {
            // Ir base de datos
            List<Persona> personas = new List<Persona>();
            if (Session["personas"] == null)
            {
                new Persona { PersonaId = 1, Nombres = "Juan", Apellidos = "Perez" };
                new Persona { PersonaId = 2, Nombres = "María", Apellidos = "Lopez" };
                new Persona { PersonaId = 3, Nombres = "Carlos", Apellidos = "Gomez" };
            Session["personas"] = personas;
            }
            else
            {
                personas = (List<Persona>)Session["personas"];
            }
            return View(personas);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Persona());
        }
        [HttpPost]
        public ActionResult Create(Persona persona)
        {
            ((List<Persona>)Session["personas"]).Add(persona);
            return RedirectToAction("Index");
        }
        public ActionResult Edit()
        {
            return View();
        }
        public ActionResult Delete()
        {
            return View();
        }

    }
}