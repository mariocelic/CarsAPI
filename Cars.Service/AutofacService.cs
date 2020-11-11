using Autofac;
using Cars.Service.Interfaces;

namespace Cars.Service
{
    public class AutofacService : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
           
            builder.RegisterType<VehicleMakeService>().As<IVehicleMakeService>().InstancePerLifetimeScope();
            builder.RegisterType<VehicleModelService>().As<IVehicleModelService>().InstancePerLifetimeScope();

            builder.RegisterType<IdentityService>().As<IIdentityService>().InstancePerLifetimeScope();

            base.Load(builder);
        }

    }
}
