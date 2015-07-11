using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using Awesome.Core;
using Awesome.Web.Models;
using Ninject;
using Person = Awesome.Web.Models.ViewModels.Person;

namespace Awesome.Web.Controllers
{
    public class HomeController : Controller
    {
        private IPersonModel _personModel;

        public HomeController()
        {
            AutomapperConfiguration.Configure();
            
            var kernel = new StandardKernel(new CoreDependencyModule(), new WebDependencyModule());
            _personModel = kernel.Get<IPersonModel>();
        }
        public ActionResult Index()
        {
            return View(_personModel.GetAllPersonnel());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}