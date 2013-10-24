using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using AsegurarSA.Domain.Abstract;
using AsegurarSA.Domain.Concrete;

namespace AsegurarSA.WebUI.Infraestructura
{
    public class NinjectControllerFactory: DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }
        
        protected override IController GetControllerInstance(RequestContext
        requestContext, Type controllerType)
        {
            return controllerType == null
            ? null
            : (IController)ninjectKernel.Get(controllerType);
        }
        
        private void AddBindings()
        {
            // put bindings here
            ninjectKernel.Bind<IEmpleadoRepository>().To<EFEmpleadoRepository>();
            ninjectKernel.Bind<IClienteRepository>().To<EFClienteRepository>();
            ninjectKernel.Bind<IAlarmaRepository>().To<EFAlarmaRepositry>();

        }
    }
}