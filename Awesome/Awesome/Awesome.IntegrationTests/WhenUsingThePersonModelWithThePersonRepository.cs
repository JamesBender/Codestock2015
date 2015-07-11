using System;
using System.Linq;
using Awesome.Core;
using Awesome.Web;
using Awesome.Web.Models;
using NUnit.Framework;
using Ninject;
using Person = Awesome.Web.Models.ViewModels.Person;

namespace Awesome.IntegrationTests
{
    [TestFixture]
    public class WhenUsingThePersonModelWithThePersonRepository
    {
        private IPersonModel _personModel;

        [SetUp]
        public void SetupPersonModel()
        {
            var kernel = new StandardKernel(new CoreDependencyModule(), new WebDependencyModule());
            _personModel = kernel.Get<IPersonModel>();
            AutomapperConfiguration.Configure();
        }

        [Test]
        public void ShouldBeAbleToGetAListOfPeople()
        {
            var expectedFirstName = "Fred";
            var expectedLastName = "Flinstone";

            var result = _personModel.GetAllPersonnel();

            Assert.IsNotNull(result);
            Assert.IsNotNull(_personModel.GetAllPersonnel().Where(x => x.FirstName == expectedFirstName && x.LastName == expectedLastName).First());
        }

        [Test]
        public void ShouldBeAbleToSaveANewPerson()
        {
            var expectedFirstName = "Wilma";
            var expectedLastName = "Flinstone";

            var person = new Person { FirstName = expectedFirstName, LastName = expectedLastName };
            var personId = _personModel.SavePerson(person);

            Assert.AreNotEqual(0, personId);

            var result = _personModel.GetPerson(personId);

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedFirstName, result.FirstName);
            Assert.AreEqual(expectedLastName, result.LastName);
        }

        [Test]
        public void ShouldBeAbleToUpdateAnExistingPerson()
        {
            var wrongFirstName = "Blarney";
            var expectedFirstName = "Barney";
            var expectedLastName = "Rubble";

            var person = new Person { FirstName = wrongFirstName, LastName = expectedLastName };

            var personId = _personModel.SavePerson(person);

            Assert.AreNotEqual(0, personId);

            person = _personModel.GetPerson(personId);

            Assert.AreEqual(wrongFirstName, person.FirstName);

            person.FirstName = expectedFirstName;
            _personModel.SavePerson(personId, person);

            person = _personModel.GetPerson(personId);

            Assert.IsNotNull(person);

            Assert.AreEqual(expectedFirstName, person.FirstName);
        }

        [Test]
        public void ShouldBeAbleToDeleteAPerson()
        {
            var person = new Person();

            var personId = _personModel.SavePerson(person);

            Assert.AreNotEqual(0, personId);

            _personModel.DeletePerson(personId);

            var result = _personModel.GetPerson(personId);

            Assert.IsNull(result);
        }
    }
}
