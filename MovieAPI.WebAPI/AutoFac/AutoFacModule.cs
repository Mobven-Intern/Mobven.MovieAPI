using Autofac;
using MovieAPI.Application.Interfaces;
using MovieAPI.Application.Mappers;
using MovieAPI.Application.Services;
using MovieAPI.Domain.Repositories;
using MovieAPI.Infrastructure.Data.Context;
using MovieAPI.Infrastructure.Repositories;
using System.Reflection;
using Module = Autofac.Module;

namespace MovieAPI.WebAPI.AutoFac
{
    public class AutoFacModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {

            containerBuilder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            
            var apiAssembly = Assembly.GetExecutingAssembly();

            var repoAssembly = Assembly.GetAssembly(typeof(MovieAPIDbContext));

            var serviceAssembly = Assembly.GetAssembly(typeof(MapperProfile));
            
            containerBuilder.RegisterAssemblyTypes(apiAssembly, repoAssembly,serviceAssembly)
                .Where(x=> x.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();


            containerBuilder.RegisterGeneric(typeof(BaseService<,>)).As(typeof(IBaseService<,>)).InstancePerLifetimeScope();


            containerBuilder.RegisterAssemblyTypes(serviceAssembly, apiAssembly, repoAssembly)
                .Where(x=>x.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            // Unable to cast object of type 'Microsoft.Extensions.DependencyInjection.ServiceCollection' to type 'Autofac.ContainerBuilder'.'




            //// containerBuilder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            //containerBuilder.RegisterType<UserRepository>().As<IGenericRepository<User>>().InstancePerLifetimeScope();

            //// containerBuilder.RegisterType<MovieRepository>().As<IMovieRepository>().InstancePerLifetimeScope();
            //containerBuilder.RegisterType<MovieRepository>().As<IGenericRepository<Movie>>().InstancePerLifetimeScope();

            ////  containerBuilder.RegisterType<CommentRepository>().As<ICommentRepository>().InstancePerLifetimeScope();
            //containerBuilder.RegisterType<CommentRepository>().As<IGenericRepository<Comment>>().InstancePerLifetimeScope();

            ////  containerBuilder.RegisterType<TagRepository>().As<ITagRepository>().InstancePerLifetimeScope();
            //containerBuilder.RegisterType<TagRepository>().As<IGenericRepository<Tag>>().InstancePerLifetimeScope();

            //// containerBuilder.RegisterType<GenreRepository>().As<IGenreRepository>().InstancePerLifetimeScope();
            //containerBuilder.RegisterType<GenreRepository>().As<IGenericRepository<Genre>>().InstancePerLifetimeScope();

            //// containerBuilder.RegisterType<RateRepository>().As<IRateRepository>().InstancePerLifetimeScope();
            //containerBuilder.RegisterType<RateRepository>().As<IGenericRepository<Rate>>().InstancePerLifetimeScope();

            //containerBuilder.RegisterGeneric(typeof(BaseService<,>)).As(typeof(IBaseService<,>)).InstancePerLifetimeScope();
            //containerBuilder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
            //containerBuilder.RegisterType<MovieService>().As<IMovieService>().InstancePerLifetimeScope();
            //containerBuilder.RegisterType<CommentService>().As<ICommentService>().InstancePerLifetimeScope();
            //containerBuilder.RegisterType<TagService>().As<ITagService>().InstancePerLifetimeScope();
            //containerBuilder.RegisterType<GenreService>().As<IGenreService>().InstancePerLifetimeScope();
            //containerBuilder.RegisterType<RateService>().As<IRateService>().InstancePerLifetimeScope();
            //containerBuilder.RegisterType<PasswordHasher<User>>().As<IPasswordHasher<User>>().InstancePerLifetimeScope();
            //containerBuilder.RegisterType<AuthService>().As<IAuthService>().InstancePerLifetimeScope();



        }
    }
}
