﻿using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Routing;
using UGroopData.Sql.Service.UGroopWeb.Concrete;
using UGroopData.Sql.Service.UGroopWeb.Interface;

namespace Ugroop.API.SQL {
    public class WebApiApplication : System.Web.HttpApplication {
        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);

            UnityConfig.RegisterComponents();
        }
     
    }
}
