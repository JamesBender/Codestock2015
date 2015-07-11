using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Awesome.Core;
using Awesome.Web.Models;
using Ninject;
using Person = Awesome.Web.Models.ViewModels.Person;

namespace Awesome.Web.Controllers
{
    public class PersonController : ApiController
    {
        private IPersonModel _personModel;

        public PersonController()
        {
            AutomapperConfiguration.Configure();
            
            var kernel = new StandardKernel(new CoreDependencyModule(), new WebDependencyModule());
            _personModel = kernel.Get<IPersonModel>();
        }

        public IEnumerable<Person> Get() 
        {
            return _personModel.GetAllPersonnel();
        }

        public Person Get(int id)
        {
            return _personModel.GetPerson(id);
        }

        public int Post(Person value)
        {
            return _personModel.SavePerson(value);
        }

        public void Put(int id, Person value)
        {
            _personModel.SavePerson(id, value);
        }

        public void Delete(int id)
        {
            _personModel.DeletePerson(id);
        }

        public IEnumerable<Person> GetPersonByFirstName(string firstName)
        {
            return _personModel.GetAllPersonnel().Where(p => p.FirstName == firstName);
        }

        public IEnumerable<Person> GetPersonByLastName(string lastName)
        {
            return _personModel.GetAllPersonnel().Where(p => p.LastName == lastName);
        }

        public IEnumerable<Person> GetPersonByFirstAndLastName(string firstName, string lastName)
        {
            return _personModel.GetAllPersonnel().Where(p => p.FirstName == firstName && p.LastName == lastName);
        }
    }
}