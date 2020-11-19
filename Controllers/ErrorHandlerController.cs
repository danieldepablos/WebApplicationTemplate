using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class ErrorHandlerController : Controller
    {
        // GET: ErrorHandler
        public ActionResult Index()
        {
            Response.StatusCode = 500;
            Response.TrySkipIisCustomErrors = true;
            return View();
        }

        public ActionResult ApplicationError(int error, string message)
        {

            switch (error)
            {
                case 500:
                    ViewBag.Title = "Ha ocurrido una excepcion en el aplicativo.";
                    ViewBag.Description = "Hemos detectado y registrado el origen de la excepcion. Nuestro equipo ha sido informado y gestionara su caso.";
                    break;

                case 404:
                    ViewBag.Title = "Enlace No Encontrado";
                    ViewBag.Description = "La URL que Ud. está intentando accesar no existe.";
                    break;

                default:
                    ViewBag.Title = "Página no encontrada";
                    ViewBag.Description = "Lo sentimos, esta página parece no existir. :( ..";
                    break;
            }

            ViewBag.Error = error;
            return View("~/Views/Helper/_ErrorPage.cshtml");
        }

    }
}