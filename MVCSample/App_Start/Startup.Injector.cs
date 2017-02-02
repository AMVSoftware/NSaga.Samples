using System.Reflection;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using MVCSample.Infrastructure;
using MVCSample.Models;
using NSaga.SimpleInjector;
using Owin;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;

namespace MVCSample
{
    public partial class Startup
    {
        public void ConfigureInjector(IAppBuilder appBuilder)
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            container.RegisterNSagaComponents()
                     .UseSqlServer()
                     .WithConnectionStringName("DefaultConnection");

            container.Register<ApplicationDbContext>();
            container.Register<ApplicationUserManager>();
            container.Register<ApplicationSignInManager>();
            container.Register<HttpCurrentWrapper>();
            container.Register<ApplicationUserStore>();

            container.Register<IPrincipal, AspNetPrincipalProxy>();

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.Register<IAuthenticationManager>(() => HttpContext.Current.GetOwinContext().Authentication);

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }


    public class HttpCurrentWrapper
    {
        public HttpContext GetCurrentHttpContext()
        {
            return HttpContext.Current;
        }
    }
}