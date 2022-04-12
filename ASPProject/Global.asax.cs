using ASPProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ASPProject
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ProjectDBContext>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<ProjectDBContext>());
            //Database.SetInitializer(new CreateDatabaseIfNotExists<ASPProject.Models.ProjectDBContext>());
        }
    }
}
