using System;
using System.Collections.Generic;
using System.Linq;
using Awesome.Core;
using Awesome.Web.Models;
using NUnit.Framework;
using Telerik.JustMock;
using Person = Awesome.Web.Models.ViewModels.Person;

namespace Awesome.Web.UnitTests.Models
{
    [TestFixture]
    public class WhenUsingThePersonModel
    {
        private IPersonRepository _personRepository;
        private PersonModel _personModel;

        [SetUp]
        public void SetupPersonModelForTesting()
        {
            AutomapperConfiguration.Configure();
            _personRepository = Mock.Create<IPersonRepository>();

            

            _personModel = new PersonModel(_personRepository);
        }

        [Test]
        public void ShouldBeAbleToGetAPerson()
        {
            var expectedFirstName = "Barney";
            var expectedLastName = "Rubble";
            var expectedUserId = 2;

            Mock.Arrange(() => _personRepository.GetPerson(expectedUserId))
                .Returns(new Core.Person { FirstName = expectedFirstName, LastName = expectedLastName, UserId = expectedUserId });

            var result = _personModel.GetPerson(expectedUserId);

            _personModel.GetPerson(1);

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedFirstName, result.FirstName);
            Assert.AreEqual(expectedLastName, result.LastName);
            Assert.AreEqual(expectedUserId, result.UserId);
        }

        [Test]
        public void ShouldBeAbleToGetAListOfAllPeople()
        {
            Mock.Arrange(() => _personRepository.GetListOfPeople())
                .Returns(new List<Core.Person>{new Core.Person()});
            var result = _personModel.GetAllPersonnel();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.ToList<Person>().Count);
        }

        [Test]
        public void ShouldBeAbleToAddAPerson()
        {  
            var firstName = "Wilma";
            var lastName = "Filnstone";
            var userId = 3;

            Mock.Arrange(() => _personRepository
                .SavePerson(Arg.Matches<Core.Person>(x => x.FirstName == firstName && x.LastName == lastName)))
                .Returns(userId);

            var savedPerson = new Person { FirstName = firstName, LastName = lastName, UserId = userId };
            
            var result = _personModel.SavePerson(savedPerson);

            Assert.AreEqual(userId, result);
        }

        [Test]
        public void ShouldBeAbleToUpdateAPerson()
        {
            var userId = 3;
            var firstName = "Wilma";
            var lastName = "Flinstone";

            Mock.Arrange(() => _personRepository
                .SavePerson(userId, Arg.Matches<Core.Person>(x => x.FirstName == firstName && x.LastName == lastName)))
                .Returns(userId);
            var savedPerson = new Person { FirstName = firstName, LastName = lastName, UserId = userId };

            var result = _personModel.SavePerson(userId, savedPerson);

            Assert.AreEqual(userId, result);
        }

        [Test]
        public void ShouldBeAbleToDeleteAPerson()
        {
            var userId = 3;

            _personModel.DeletePerson(userId);

            Mock.Assert(() => _personRepository.DeletePerson(userId), Occurs.Once());
        }
    }
}
