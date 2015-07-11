using System;
using Ninject.Modules;

namespace Awesome.Core
{
    public class CoreDependencyModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IPersonRepository>().To<PersonRepository>();
        }
    }
}