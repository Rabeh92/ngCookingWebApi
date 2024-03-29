using ngCookingWebApi.Persistance;
using ngCookingWebApi.Persistance.Repositories.Abstract;
using ngCookingWebApi.Persistance.Repositories.Concrete;
using System.Web.Http;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.WebApi;
using AutoMapper;
namespace ngCookingWebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            var context = ApplicationDbContext.Create();
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            container.RegisterType<IUnitOfWork, UnitOfWork>(new InjectionConstructor(context));
            container.RegisterType<IIngredientRepository, IngredientRepository>(new InjectionConstructor(context));
            container.RegisterType<IRecetteRepository, RecetteRepository>(new InjectionConstructor(context));
            container.RegisterType<ICommentRepository, CommentRepository>(new InjectionConstructor(context));
            container.RegisterType<IMapper, Mapper>(new InjectionConstructor(MappingProfile.GetConfiguration()));
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}