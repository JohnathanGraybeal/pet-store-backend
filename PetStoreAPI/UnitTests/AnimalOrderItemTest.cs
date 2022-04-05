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
    public class AnimalOrderItemTest
    {
        /// <summary>
        /// Tests that Create method creates a new entry.
        /// public async Task<ActionResult<AnimalOrderItem>> Post(AnimalOrderItem animalOrderItem)
        /// </summary>
        /// <returns>CreatedAtActionResult</returns>
        [Test]
        public async Task Create_Adds_AnimalOrderItem()
        {
            //Arrange
            var fakeAnimalOrderItem = A.Dummy<AnimalOrderItem>();
            var dataStore = A.Fake<IAnimalOrderItemRepository>();
            A.CallTo(() => dataStore.CreateAsync(fakeAnimalOrderItem)).Returns(Task.FromResult(fakeAnimalOrderItem));
            var controller = new AnimalOrderItemController(dataStore);

            //Act
            var actionResult = await controller.Post(fakeAnimalOrderItem);

            //Assert
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsNotNull(result);   // Checks that an entry is created.
            Assert.AreEqual(0, result.RouteValues["OrderId"]);   // Checks that the OrderId of the entry is what was submitted.
        }

        /// <summary>
        /// Tests that GetAll method returns list of all entries
        /// public async Task<ActionResult<IEnumerable<AnimalOrderItem>>> GetAll()
        /// </summary>
        /// <returns>OkObjectResult</returns>
        [Test]
        public async Task GetAll_Returns_All_Values()
        {
            //Arrange
            int count = 3;
            var fakeAnimalOrderItems = A.CollectionOfDummy<AnimalOrderItem>(count).AsEnumerable();
            var dataStore = A.Fake<IAnimalOrderItemRepository>();
            A.CallTo(() => dataStore.ReadAllAsync()).Returns(Task.FromResult(fakeAnimalOrderItems));
            var controller = new AnimalOrderItemController(dataStore);

            //Act
            var actionResult = await controller.GetAll();

            //Assert
            var result = actionResult.Result as OkObjectResult;
            var returnAnimalOrderItems = result.Value as IEnumerable<AnimalOrderItem>;
            Assert.AreEqual(count, returnAnimalOrderItems.Count());    // Checks that the size of the returned list is the same as the original
        }

        /// <summary>
        /// Tests that GetOne method gets one entry with given Id
        /// public async Task<ActionResult<AnimalOrderItem>> GetOne(int Id)
        /// </summary>
        /// <returns>OkObjectResult</returns>
        [Test]
        public async Task GetOne_Gets_Same_ID()
        {
            //Arrange
            int OrderId = 1;
            int AnimalId = 1;
            var fakeAnimalOrderItem = A.Fake<AnimalOrderItem>();
            fakeAnimalOrderItem.AnimalOrderId = OrderId;
            fakeAnimalOrderItem.AnimalId = AnimalId;
            var fakeAnimalOrderItem2 = A.Fake<AnimalOrderItem>();
            fakeAnimalOrderItem2.AnimalOrderId = 2;
            fakeAnimalOrderItem2.AnimalId = 2;
            var dataStore = A.Fake<IAnimalOrderItemRepository>();
            A.CallTo(() => dataStore.ReadAsync(OrderId, AnimalId)).Returns(Task.FromResult(fakeAnimalOrderItem));
            var controller = new AnimalOrderItemController(dataStore);

            //Act
            var actionResult = await controller.GetOne(OrderId, AnimalId);

            //Assert
            var result = actionResult.Result as OkObjectResult;
            var returnAnimalOrderItem = result.Value;
            Assert.IsNotNull(returnAnimalOrderItem);   // Checks that returned entry is not null
            Assert.AreEqual(fakeAnimalOrderItem, result.Value);    // Checks that returned entry is the entry with given ID
        }

        /// <summary>
        /// Tests that Update method updates a given entry with passing status code
        /// public async Task<ActionResult<AnimalOrderItem>> Put(AnimalOrderItem Updated)
        /// </summary>
        /// <returns>NoContentResult</returns>
        [Test]
        public async Task Put_Updates_Entry()
        {
            //Arrange
            var fakeAnimalOrderItem = A.Dummy<AnimalOrderItem>();
            var dataStore = A.Fake<IAnimalOrderItemRepository>();
            A.CallTo(() => dataStore.UpdateAsync(0, 0, fakeAnimalOrderItem)).Returns(Task.FromResult(fakeAnimalOrderItem));
            var controller = new AnimalOrderItemController(dataStore);

            //Act
            var actionResult = await controller.Put(fakeAnimalOrderItem);

            //Assert
            var result = actionResult.Result as NoContentResult;
            Assert.IsNotNull(result);   // Checks that an entry is updated.
            Assert.IsInstanceOf<NoContentResult>(result);   // Checks that the result is of the correct type
            Assert.AreEqual(204, result.StatusCode);    // Checks that correct status code is given
        }

        /// <summary>
        /// Tests that Remove method deletes a given entry
        /// public async Task<ActionResult<AnimalOrderItem>> Remove(int Id)
        /// </summary>
        /// <returns>NoContentResult</returns>
        [Test]
        public async Task Remove_deletes_Entry()
        {
            //Arrange
            int OrderId = 1;
            int AnimalId = 1;
            var fakeAnimalOrderItem = A.Dummy<AnimalOrderItem>();
            var dataStore = A.Fake<IAnimalOrderItemRepository>();
            A.CallTo(() => dataStore.DeleteAsync(OrderId, AnimalId)).Returns(Task.FromResult(fakeAnimalOrderItem));
            var controller = new AnimalOrderItemController(dataStore);

            //Act
            var actionResult = await controller.Remove(OrderId, AnimalId);

            //Assert
            var result = actionResult.Result as NoContentResult;
            Assert.IsNotNull(result);   // Checks that an entry is deleted.
            Assert.IsInstanceOf<NoContentResult>(result);   // Checks that the result is of the correct type
            Assert.AreEqual(204, result.StatusCode);    // Checks that correct status code is given
        }
    }
}
