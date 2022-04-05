using FakeItEasy;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using PetStoreAPI.Controllers;
using PetStoreAPI.Models.Entities;
using PetStoreAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTests
{    
    public class SaleAnimalTest
    {
        /// <summary>
        /// Tests that Create method creates a new entry.
        /// public async Task<ActionResult<SaleAnimal>> Post(SaleAnimal saleAnimal)
        /// </summary>
        /// <returns>CreatedAtActionResult</returns>
        [Test]
        public async Task Create_Adds_SaleAnimal()
        {
            //Arrange
            var fakeSaleAnimal = A.Dummy<SaleAnimal>();
            var dataStore = A.Fake<ISaleAnimalRepository>();
            A.CallTo(() => dataStore.CreateAsync(fakeSaleAnimal)).Returns(Task.FromResult(fakeSaleAnimal));
            var controller = new SaleAnimalController(dataStore);

            //Act
            var actionResult = await controller.Post(fakeSaleAnimal);

            //Assert
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsNotNull(result);   // Checks that an entry is created.
            Assert.AreEqual(0, result.RouteValues["AnimalId"]);   // Checks that the Id of the entry is what was submitted.
        }

        /// <summary>
        /// Tests that GetAll method returns list of all entries
        /// public async Task<ActionResult<IEnumerable<Sale>>> GetAll()
        /// </summary>
        /// <returns>OkObjectResult</returns>
        [Test]
        public async Task GetAll_Returns_All_Values()
        {
            //Arrange
            int count = 3;
            var fakeSaleAnimals = A.CollectionOfDummy<SaleAnimal>(count).AsEnumerable();
            var dataStore = A.Fake<ISaleAnimalRepository>();
            A.CallTo(() => dataStore.ReadAllAsync()).Returns(Task.FromResult(fakeSaleAnimals));
            var controller = new SaleAnimalController(dataStore);

            //Act
            var actionResult = await controller.GetAll();

            //Assert
            var result = actionResult.Result as OkObjectResult;
            var returnSaleAnimals = result.Value as IEnumerable<SaleAnimal>;
            Assert.AreEqual(count, returnSaleAnimals.Count());    // Checks that the size of the returned list is the same as the original
        }

        /// <summary>
        /// Tests that GetOne method gets one entry with given Id
        /// public async Task<ActionResult<Sale>> GetOne(int Id)
        /// </summary>
        /// <returns>OkObjectResult</returns>
        [Test]
        public async Task GetOne_Gets_Same_ID()
        {
            //Arrange
            int Id = 1;
            var fakeSaleAnimal = A.Fake<SaleAnimal>();
            fakeSaleAnimal.SaleId = Id;
            fakeSaleAnimal.AnimalId = Id;
            var fakeSaleAnimal2 = A.Fake<SaleAnimal>();
            fakeSaleAnimal2.SaleId = 2;
            fakeSaleAnimal2.AnimalId = 2;
            var dataStore = A.Fake<ISaleAnimalRepository>();
            A.CallTo(() => dataStore.ReadAsync(Id, Id)).Returns(Task.FromResult(fakeSaleAnimal));
            var controller = new SaleAnimalController(dataStore);

            //Act
            var actionResult = await controller.GetOne(Id, Id);

            //Assert
            var result = actionResult.Result as OkObjectResult;
            var returnSaleAnimal = result.Value;
            Assert.IsNotNull(returnSaleAnimal);   // Checks that returned entry is not null
            Assert.AreEqual(fakeSaleAnimal, result.Value);    // Checks that returned entry is the entry with given ID
        }

        /// <summary>
        /// Tests that Update method updates a given entry with passing status code
        /// public async Task<ActionResult<Sale>> Put(Sale Updated)
        /// </summary>
        /// <returns>NoContentResult</returns>
        [Test]
        public async Task Put_Updates_Entry()
        {
            //Arrange
            var fakeSaleAnimal = A.Dummy<SaleAnimal>();
            var dataStore = A.Fake<ISaleAnimalRepository>();
            A.CallTo(() => dataStore.UpdateAsync(0, 0, fakeSaleAnimal)).Returns(Task.FromResult(fakeSaleAnimal));
            var controller = new SaleAnimalController(dataStore);

            //Act
            var actionResult = await controller.Put(fakeSaleAnimal);

            //Assert
            var result = actionResult.Result as NoContentResult;
            Assert.IsNotNull(result);   // Checks that an entry is updated.
            Assert.IsInstanceOf<NoContentResult>(result);   // Checks that the result is of the correct type
            Assert.AreEqual(204, result.StatusCode);    // Checks that correct status code is given

        }

        /// <summary>
        /// Tests that Remove method deletes a given entry
        /// public async Task<ActionResult<Sale>> Remove(int Id)
        /// </summary>
        /// <returns>NoContentResult</returns>
        [Test]
        public async Task Remove_deletes_Entry()
        {
            //Arrange
            int Id = 1;
            var fakeSaleAnimal = A.Dummy<SaleAnimal>();
            var dataStore = A.Fake<ISaleAnimalRepository>();
            A.CallTo(() => dataStore.DeleteAsync(Id, Id)).Returns(Task.FromResult(fakeSaleAnimal));
            var controller = new SaleAnimalController(dataStore);

            //Act
            var actionResult = await controller.Remove(Id, Id);

            //Assert
            var result = actionResult.Result as NoContentResult;
            Assert.IsNotNull(result);   // Checks that an entry is deleted.
            Assert.IsInstanceOf<NoContentResult>(result);   // Checks that the result is of the correct type
            Assert.AreEqual(204, result.StatusCode);    // Checks that correct status code is given
        }
    }
}