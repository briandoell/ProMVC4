using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MvcMusicStore
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            System.Data.Entity.Database.SetInitializer(new MusicStoreInitializer());
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }
    }

    public class MusicStoreInitializer : System.Data.Entity.DropCreateDatabaseAlways<MvcMusicStore.Models.MvcMusicStoreContext>
    {
        protected override void Seed(Models.MvcMusicStoreContext context)
        {
            context.Artists.Add(new Models.Artist { Name = "Al Di Meola" });
            context.Genres.Add(new Models.Genre { Name = "Jazz" });

            context.Albums.Add(new Models.Album
            {
                Artist = new Models.Artist { Name = "Rush" },
                Genre = new Models.Genre { Name = "Rock" },
                Price = 9.99m,
                Title = "Carvan"
            });

            base.Seed(context);
        }
    }
}