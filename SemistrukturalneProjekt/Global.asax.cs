using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SemistrukturalneProjekt
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DocumentDBRepository<SemistrukturalneProjekt.Models.Lodówki>.Initialize();
            DocumentDBRepository<SemistrukturalneProjekt.Models.Zamrażarki>.Initialize();
            DocumentDBRepository<SemistrukturalneProjekt.Models.Pralko_Suszarki>.Initialize();
            DocumentDBRepository<SemistrukturalneProjekt.Models.Wirówki>.Initialize();
            DocumentDBRepository<SemistrukturalneProjekt.Models.Kuchnie>.Initialize();
            DocumentDBRepository<SemistrukturalneProjekt.Models.Miksery>.Initialize();
            DocumentDBRepository<SemistrukturalneProjekt.Models.Counter>.Initialize();
            DocumentDBRepository<SemistrukturalneProjekt.Models.General>.Initialize();
            DBCounter.Licznik();
        }
    }
}
