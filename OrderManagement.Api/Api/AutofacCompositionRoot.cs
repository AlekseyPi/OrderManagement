using System;
using Autofac;
using OrderManagement.Api.Data;
using OrderManagement.Api.Data.Implementation;

namespace OrderManagement.Api.Api
{
    public class AutofacCompositionRoot: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MockOrdersRepository>().As<IOrdersRepository>().SingleInstance();
            builder.RegisterType<MockProductsRepository>().As<IProductsRepository>().SingleInstance();
        }
    }
}
