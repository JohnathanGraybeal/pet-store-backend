using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using PetStoreAPI.Controllers;
using PetStoreAPI.Models.Entities;
using PetStoreAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class AnimalTests
    {

        [Test]
        public async Task Create_Adds_Animal()
        {
            //Arrange
            var fakeAnimal = A.Dummy<Animal>();
            var dataStore = A.Fake<IAnimalRepository>();
            A.CallTo(() => dataStore.CreateAsync(fakeAnimal)).Returns(Task.FromResult(fakeAnimal));
            var controller = new AnimalController(dataStore);

            //Act
            var actionResult = await controller.Post(fakeAnimal);

            //Assert
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsNotNull(result);   // Checks that an entry is created.
        }

        [Test]
        public async Task GetAll_Returns_All_Values()
        {
            //Arrange
            int count = 3;
            var fakeAnimals = A.CollectionOfDummy<Animal>(count).AsEnumerable();
            var dataStore = A.Fake<IAnimalRepository>();
            A.CallTo(() => dataStore.ReadAllAsync()).Returns(Task.FromResult(fakeAnimals));
            var controller = new AnimalController(dataStore);

            //Act
            var actionResult = await controller.GetAll(1, 20);

            //Assert
            var result = actionResult.Result as OkObjectResult;
            var returnAnimals = result.Value as IEnumerable<Animal>;
            Assert.AreEqual(count, returnAnimals.Count());    // Checks that the size of the returned list is the same as the original
        }

        [Test]
        public async Task GetOne_Gets_Same_ID()
        {
            //Arrange
            int Id = 1;
            var fakeAnimal = A.Fake<Animal>();
            fakeAnimal.Id = Id;
            var fakeAnimal2 = A.Fake<Animal>();
            fakeAnimal2.Id = 2;
            var dataStore = A.Fake<IAnimalRepository>();
            A.CallTo(() => dataStore.ReadAsync(Id)).Returns(Task.FromResult(fakeAnimal));
            var controller = new AnimalController(dataStore);

            //Act
            var actionResult = await controller.GetOne(Id);

            //Assert
            var result = actionResult.Result as OkObjectResult;
            var returnRevision = result.Value;
            Assert.IsNotNull(returnRevision);   // Checks that returned entry is not null
            Assert.AreEqual(fakeAnimal, result.Value);    // Checks that returned entry is the entry with given ID
        }

        [Test]
        public async Task Put_Updates_Entry()
        {
            //Arrange
            var fakeAnimal = A.Dummy<Animal>();
            var dataStore = A.Fake<IAnimalRepository>();
            A.CallTo(() => dataStore.UpdateAsync(0, fakeAnimal)).Returns(Task.FromResult(fakeAnimal));
            var controller = new AnimalController(dataStore);

            //Act
            var actionResult = await controller.Put(fakeAnimal);

            //Assert
            var result = actionResult.Result as NoContentResult;
            Assert.IsNotNull(result);   // Checks that an entry is updated.
            Assert.IsInstanceOf<NoContentResult>(result);   // Checks that the result is of the correct type
            Assert.AreEqual(204, result.StatusCode);    // Checks that correct status code is given
        }

        [Test]
        public async Task Remove_deletes_Entry()
        {
            //Arrange
            int Id = 1;
            var fakeAnimal = A.Dummy<Animal>();
            var dataStore = A.Fake<IAnimalRepository>();
            A.CallTo(() => dataStore.DeleteAsync(Id)).Returns(Task.FromResult(fakeAnimal));
            var controller = new AnimalController(dataStore);

            //Act
            var actionResult = await controller.Remove(Id);

            //Assert
            var result = actionResult.Result as NoContentResult;
            Assert.IsNotNull(result);   // Checks that an entry is deleted.
            Assert.IsInstanceOf<NoContentResult>(result);   // Checks that the result is of the correct type
            Assert.AreEqual(204, result.StatusCode);    // Checks that correct status code is given
        }
    }
}
