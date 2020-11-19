using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Helpers;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {

        private static readonly NLog.Logger _Logger = NLog.LogManager.GetCurrentClassLogger();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            try
            {

                Email email = new Email();
                email.To.Add("ddepabloss@gmail.com");
                email.From = "danieldepablos@gmail.com";
                email.Subject = "Email from ASP.NET WebApplication";
                email.Body = "<p><strong>Hello</strong></p><p>This is my first Email Message</p>";
                email.Send();

            }
            catch (Exception ex)
            {

                //Logger.Error(string.Format("{0}|{1}|{2}", Global.ERROR_APPLICATION, ex.Message, ex.StackTrace));

                throw ex;
            
            }

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //protected override void OnException(ExceptionContext filterContext)
        //{
        //    filterContext.ExceptionHandled = true;

        //    //Log the error!!
        //    //_Logger.Error(filterContext.Exception);
        //    _Logger.Error(filterContext.Exception.Message);

        //    //Redirect or return a view, but not both.
        //    //filterContext.Result = RedirectToAction("Index", "ErrorHandler");
        //    // OR 
        //    filterContext.Result = new ViewResult
        //    {
        //        ViewName = "~/Views/ErrorHandler/Index.cshtml"
        //        //ViewName = "~/Views/helper/_ErrorPage.cshtml"
        //    };
        //}


    }
}