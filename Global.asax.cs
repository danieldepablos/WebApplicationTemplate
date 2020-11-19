using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebApplication
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static readonly NLog.Logger _Logger = NLog.LogManager.GetCurrentClassLogger();

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error(object sender, EventArgs e)
        {

            Exception exception = Server.GetLastError();
            Response.Clear();

            HttpException httpException = exception as HttpException;

            int error = httpException != null ? httpException.GetHttpCode() : 500;

            Server.ClearError();

            _Logger.Error(String.Format("{0}|{1}", error, exception));

            //_Logger.Error(filterContext.Exception);

            //Response.Redirect(String.Format("~/ErrorHandler/ApplicationError?error={0}&message={1}", error, exception.Message));
            Response.Redirect(String.Format("~/ErrorHandler/ApplicationError?error={0}", error, exception.Message));

        }

    }
}
