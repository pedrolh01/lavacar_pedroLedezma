using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc; 

namespace carw.Controllers
{
    public class VehiculoController : Controller
    {
        // GET: Vehiculo
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Crear()
        { 
            return View();
        }
        [HttpPost]
        public ActionResult Crear(Entidades.Vehiculo collection)
        {
            try
            { 
                LogicaNegocio.Vehiculo vv = new LogicaNegocio.Vehiculo();
                vv.Crear(collection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}