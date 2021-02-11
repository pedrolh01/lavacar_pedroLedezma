using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace carw.Controllers
{
    public class ServicioController : Controller
    {
        // GET: Servicio
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Crear(Entidades.Servicios collection)
        {
            try
            { 
                LogicaNegocio.Servicio vv = new LogicaNegocio.Servicio();
                vv.Crear(collection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Lista()
        {
            try
            {
                LogicaNegocio.Servicio ss = new LogicaNegocio.Servicio();
                Entidades.Servicios[] ddss = ss.getAll();
                ViewBag.Servicios = ddss;
                return View();
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public ActionResult GenerarReporte()
        {
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult GenerarReporte(int action = 0)
        {
            
            try
            {
                if (action == 0)
                {

                }
                else {
                    LogicaNegocio.VehiculoServicio vs = new LogicaNegocio.VehiculoServicio();

                    Entidades.VehiculoServicio[] ddvs = vs.Reporte(action);
                    ViewBag.VehiculoServicio = ddvs;
                } 
                return View();
            }
            catch
            {
                return RedirectToAction("Index");
            }
             
        }
    }
}