using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Ninject;
using Ninject.Syntax;
using Tutorial.Application;
using Tutorial.Persistence;

namespace Tutorial.App_Start
{
    public class IocConfig
    {

        public static void ConfigurarDependencias()
        {
            //Cria o Container 
            IKernel kernel = new StandardKernel();

            //Instrução para mapear a interface IPessoa para a classe concreta Pessoa
            kernel.Bind<ICavaloDAO>().To<CavaloDAO>();

            //kernel.Bind<ICrudService>().To<CrudService>();

            kernel.Bind<ICavaloService>().To<CavaloService>();

            //GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);

            //Registra o container no ASP.NET
            DependencyResolver.SetResolver(new NinjectDependencyResolver1(kernel));
        }


    }

     
    public class NinjectDependencyResolver1 : IDependencyResolver
    {
        private readonly IResolutionRoot _resolutionRoot;

        public NinjectDependencyResolver1(IResolutionRoot kernel)
        {
            _resolutionRoot = kernel;
        }

        public object GetService(Type serviceType)
        {
            return _resolutionRoot.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _resolutionRoot.GetAll(serviceType);
        }
    }

    

}