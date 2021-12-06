using Laboratorio10.Models;
using Laboratorio10.Handlers;
using System.Web.Mvc;
using System;

namespace Laboratorio10.Controllers
{
    public class PlanetasController : Controller
    {
        public PlanetasHandler accesoDatos { get; set; }

        public PlanetasController() {
            accesoDatos = new PlanetasHandler();
        }

        public PlanetasController(PlanetasHandler planetaHandler) {
            accesoDatos = planetaHandler;
        }


        public ActionResult listadoDePlanetas()
        {
            
            ViewBag.planetas = accesoDatos.obtenerTodosLosPlanetas();
            return View();
        }

        public ActionResult crearPlaneta()
        {
            return View("crearPlaneta");
        }

        [HttpPost]
        public ActionResult crearPlaneta(PlanetaModel planeta)
        {
            ViewBag.ExitoAlCrear = false;
            try
            {
                if (ModelState.IsValid)
                {
                    ViewBag.ExitoAlCrear = accesoDatos.crearPlaneta(planeta);
                    if (ViewBag.ExitoAlCrear)
                    {
                        ViewBag.Message = "El planeta " + planeta.nombre + " fue creado con éxito :)";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch
            {
                ViewBag.Message = "Algo salió mal y no fue posible crear el planeta :(";
                return View();
            }
        }

        [HttpGet]
        public ActionResult editarPlaneta(int ? identificador)
        {
            ActionResult vista;
            try
            {
                PlanetaModel planetaModificar = accesoDatos.obtenerTodosLosPlanetas().Find(smodel => smodel.id == identificador);
                if (planetaModificar == null)
                {
                    vista = RedirectToAction("listadoDePlanetas");
                }
                else
                {
                    vista = View(planetaModificar);
                }
            }
            catch
            {
                vista = RedirectToAction("listadoDePlanetas");
            }
            return vista;
        }

        [HttpPost]
        public ActionResult editarPlaneta(PlanetaModel planeta)
        {
            try
            {
                accesoDatos.modificarPlaneta(planeta);
                return RedirectToAction("listadoDePlanetas");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public FileResult accederArchivo(int identificador)
        {
            try
            {
                var tupla = accesoDatos.descargarContenido(identificador);
                FileResult file = File(tupla.Item1, tupla.Item2);
                return file;
            }
            catch
            {
                return null;
            }
        }
    }
}