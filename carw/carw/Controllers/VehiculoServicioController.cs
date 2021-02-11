using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace carw.Controllers
{
    public class VehiculoServicioController : Controller
    {
        // GET: VehiculoServicio
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Crear()
        {
            try
            {
                LogicaNegocio.Servicio ss = new LogicaNegocio.Servicio();
                Entidades.Servicios[] ddss = ss.getAll();
                LogicaNegocio.Vehiculo vv = new LogicaNegocio.Vehiculo();
                Entidades.Vehiculo[] ddvv = vv.getAll();
                ViewBag.Vehiculos = ddvv;
                ViewBag.Servicios = ddss;
                return View();
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public ActionResult Crear(Entidades.VehiculoServicio collection)
        {
            try
            { 
                LogicaNegocio.VehiculoServicio vv = new LogicaNegocio.VehiculoServicio(); 
                vv.Crear(collection);
                return RedirectToAction("Index"); 
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
        
        
        
    }
}