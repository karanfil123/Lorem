using Autofac;
using Lorem.Caching.CachingProducts;
using Lorem.Core.Repository;
using Lorem.Core.Service;
using Lorem.Core.UnitOfWork;
using Lorem.Repository;
using Lorem.Repository.Repositories;
using Lorem.Repository.UnitOfWork;
using Lorem.Service.Mapping;
using Lorem.Service.Services;
using System.Reflection;

namespace Lorem.Api.Modules
{
    public class RepositoryServicesModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            var api = Assembly.GetExecutingAssembly();
            var repo = Assembly.GetAssembly(typeof(AppDbContext));
            var service = Assembly.GetAssembly(typeof(MapProfile));

            builder.RegisterAssemblyTypes(api, repo, service).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(api, repo, service).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<ProductServiceWithCaching>().As<IProductService>().InstancePerLifetimeScope();
        }
    }
}
