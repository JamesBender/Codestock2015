using System;
using System.Collections.Generic;

namespace Awesome.Core
{
    public interface IPersonRepository
    {
        Person GetPerson(int userId);

        int SavePerson(Person addedPerson);

        int SavePerson(int userId, Person updatedPerson);

        void DeletePerson(int userId);

        ICollection<Person> GetListOfPeople();
    }
}