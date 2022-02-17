using Autofac;
using Autofac.Integration.Mvc;
using Practical_10_2.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practical_10_2.Web.App_Start
{
    public class ContainerConfig
    {
        internal static void RegisterContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<InMemoryUserData>()
                    .As<IUserData>()
                    .SingleInstance();
            // builder.RegisterType<OdeToFoodDbcontext>().InstancePerRequest();
            var container = builder.Build();


            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}