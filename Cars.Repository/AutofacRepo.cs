using Autofac;
using Cars.DAL;
using Cars.DAL.Abstract;
using Cars.Repository.Common;
using Microsoft.EntityFrameworkCore;

namespace Cars.Repository
{
    public class AutofacRepo : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().AsSelf().As<DbContext>().InstancePerLifetimeScope();
            builder.RegisterType<ApplicationDbContext>().As<IApplicationDbContext>().InstancePerLifetimeScope();

            builder.RegisterType<VehicleMakeRepository>().As<IVehicleMakeRepository>().InstancePerLifetimeScope();
            builder.RegisterType<VehicleModelRepository>().As<IVehicleModelRepository>().InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            base.Load(builder);
        }

    }
}
