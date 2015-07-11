using System;
using System.Linq;
using NinjectDemo.Core;

namespace Ninject.App
{
    class Program
    {
        static void Main(string[] args)
        {            
            Console.WriteLine("============================================");

            var kernel = new StandardKernel(new DomainModule());
            var diLibrary = kernel.Get<IDiBusinessLibrary>();
            diLibrary.DoStuff();

            Console.WriteLine();
            Console.WriteLine("Done, press any key to continue.");
            Console.ReadKey();
        }
    }
}
