using Autofac;
using AutoMapper;
using Cars.Service.Common;

namespace Cars.Service
{
    public class AutofacService : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
           
            builder.RegisterType<VehicleMakeService>().As<IVehicleMakeService>().InstancePerLifetimeScope();
            builder.RegisterType<VehicleModelService>().As<IVehicleModelService>().InstancePerLifetimeScope();
           
            base.Load(builder);
        }

    }
}
