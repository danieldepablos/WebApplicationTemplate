using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class ErrorController : Controller
    {

        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        // GET: Error
        public ActionResult Index(int error = 0)
        {
            
            Logger.Error(error.ToString(), "Goodbye cruel world");

            switch (error)
            {
                case 505:
                    ViewBag.Title = "Ocurrio un error inesperado";
                    ViewBag.Description = "Todos los detalles han sido registrados.";
                    break;

                case 404:
                    ViewBag.Title = "Página no encontrada";
                    ViewBag.Description = "La URL que Ud. está intentando ingresar no existe.";
                    break;

                default:
                    ViewBag.Title = "Página no encontrada";
                    ViewBag.Description = "Lo sentimos, esta página parece no existir. :( ..";
                    break;
            }

            return View("~/views/helper/_ErrorPage.cshtml");

        }
    }
}