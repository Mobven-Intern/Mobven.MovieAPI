using Autofac;
using MovieAPI.Application.Interfaces;
using MovieAPI.Application.Mappers;
using MovieAPI.Application.Services;
using MovieAPI.Domain.Repositories;
using MovieAPI.Infrastructure.Data.Context;
using MovieAPI.Infrastructure.Repositories;
using System.Reflection;
using Module = Autofac.Module;

namespace MovieAPI.WebAPI.AutoFac;

public class AutoFacModule : Module
{
    protected override void Load(ContainerBuilder containerBuilder)
    {
        containerBuilder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
        
        var apiAssembly = Assembly.GetExecutingAssembly();

        var repoAssembly = Assembly.GetAssembly(typeof(MovieAPIDbContext)); 

        var serviceAssembly = Assembly.GetAssembly(typeof(MapperProfile));

        containerBuilder.RegisterAssemblyTypes(apiAssembly, repoAssembly)
            .Where(x=> x.Name.EndsWith("Repository"))
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope(); 

        containerBuilder.RegisterGeneric(typeof(BaseService<,>)).As(typeof(IBaseService<,>)).InstancePerLifetimeScope();

        containerBuilder.RegisterAssemblyTypes(serviceAssembly, apiAssembly)
            .Where(x=>x.Name.EndsWith("Service"))
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();
    }
}
