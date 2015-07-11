using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Awesome.Core;

namespace Awesome.Web.Models
{
    public interface IPersonModel
    {
        IEnumerable<ViewModels.Person> GetAllPersonnel();
        ViewModels.Person GetPerson(int id);
        int SavePerson(ViewModels.Person person);
        int SavePerson(int id, ViewModels.Person person);
        void DeletePerson(int id);
    }

    public class PersonModel : IPersonModel
    {
        private readonly IPersonRepository _personRepository;

        public PersonModel(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public IEnumerable<ViewModels.Person> GetAllPersonnel()
        {
            return
                Enumerable.ToList(_personRepository.GetListOfPeople()
                                     .Select(Mapper.Map<Person, ViewModels.Person>));
        }

        public ViewModels.Person GetPerson(int id)
        {
            var person = _personRepository.GetPerson(id);

            return Mapper.Map<Person, ViewModels.Person>(person);
        }

        public int SavePerson(ViewModels.Person person)
        {
            return _personRepository.SavePerson(Mapper.Map<ViewModels.Person, Person>(person));
        }

        public int SavePerson(int id, ViewModels.Person person)
        {
            return _personRepository.SavePerson(id, Mapper.Map<ViewModels.Person, Person>(person));
        }

        public void DeletePerson(int id)
        {
            _personRepository.DeletePerson(id);
        }
    }
}