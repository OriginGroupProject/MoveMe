using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace MoveMe.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //SqlServerTypes.Utilities.LoadNativeAssemblies(Server.MapPath("~/bin"));
            //HttpConfiguration config = GlobalConfiguration.Configuration;

            //config.Formatters.JsonFormatter
            //.SerializerSettings
            //.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        }
    }
}
