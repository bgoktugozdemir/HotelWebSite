using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Hotel.BI.Interface;
using Hotel.BI.Repository;
using WebProje.Controllers;

namespace WebProje.App_Start
{
    public class AutofacConfig
    {
        public static void RegisterComponents()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ServicesManagement>().As<IServicesManagement>();
            builder.RegisterType<RoomTypesManagement>().As<IRoomTypesManagement>();
            builder.RegisterType<PagesManagement>().As<IPagesManagement>();
            builder.RegisterType<TestimonialsManagement>().As<ITestimonialsManagement>();
            builder.RegisterType<CustomersManagement>().As<ICustomersManagement>();

            builder.RegisterType<HomeController>();
            builder.RegisterType<AboutController>();
            builder.RegisterType<ContactController>();
            builder.RegisterType<BlogController>();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}