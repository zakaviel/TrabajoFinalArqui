using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcShopping
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            //System.Data.Entity.IDatabaseInitializer<DAL.MusicStoreEntities> strategy = new DAL.MvcShoppingInitializer();

            //System.Data.Entity.Database.SetInitializer(strategy);
             
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
