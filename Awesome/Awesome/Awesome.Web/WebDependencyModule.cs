using System;
using Awesome.Web.Models;
using Ninject.Modules;

namespace Awesome.Web
{
    public class WebDependencyModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IPersonModel>().To<PersonModel>();
        }
    }
}