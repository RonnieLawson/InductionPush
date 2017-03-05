using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace InductionPush
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var xml = GlobalConfiguration.Configuration.Formatters.XmlFormatter;

            xml.UseXmlSerializer = true;
        }
    }
}
