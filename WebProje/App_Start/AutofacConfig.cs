﻿using Autofac;
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
            builder.RegisterType<ImagesManagement>().As<IImagesManagement>();
            builder.RegisterType<PostsManagement>().As<IPostsManagement>();
            builder.RegisterType<SettingsManagement>().As<ISettingsManagement>();
            builder.RegisterType<ContactFormsManagement>().As<IContactFormsManagement>();
            builder.RegisterType<BooksManagement>().As<IBooksManagement>();
            builder.RegisterType<RoomsManagement>().As<IRoomsManagement>();
            builder.RegisterType<EmployeesManagement>().As<IEmployeesManagement>();
            builder.RegisterType<UsersManagement>().As<IUsersManagement>();

            builder.RegisterType<HomeController>();
            builder.RegisterType<AboutController>();
            builder.RegisterType<GalleryController>();
            builder.RegisterType<BlogController>();
            builder.RegisterType<ContactController>();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}