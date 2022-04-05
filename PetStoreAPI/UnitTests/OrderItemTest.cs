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
    public class OrderItemTest
    {
        /// <summary>
        /// Tests that Create method creates a new entry.
        /// public async Task<ActionResult<OrderItem>> Post(OrderItem orderitem)
        /// </summary>
        /// <returns>CreatedAtActionResult</returns>
        [Test]
        public async Task Create_Adds_OrderItem()
        {
            //Arrange
            var fakeOrderItem = A.Dummy<OrderItem>();
            var dataStore = A.Fake<IOrderItemRepository>();
            A.CallTo(() => dataStore.CreateAsync(fakeOrderItem)).Returns(Task.FromResult(fakeOrderItem));
            var controller = new OrderItemController(dataStore);

            //Act
            var actionResult = await controller.Post(fakeOrderItem);

            //Assert
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsNotNull(result);   // Checks that an entry is created.
            Assert.AreEqual(0, result.RouteValues["PONumber"]);   // Checks that the Id of the entry is what was submitted.
        }

        /// <summary>
        /// Tests that GetAll method returns list of all entries
        /// public async Task<ActionResult<IEnumerable<OrderItem>>> GetAll()
        /// </summary>
        /// <returns>OkObjectResult</returns>
        [Test]
        public async Task GetAll_Returns_All_Values()
        {
            //Arrange
            int count = 3;
            var fakeOrderItems = A.CollectionOfDummy<OrderItem>(count).AsEnumerable();
            var dataStore = A.Fake<IOrderItemRepository>();
            A.CallTo(() => dataStore.ReadAllAsync()).Returns(Task.FromResult(fakeOrderItems));
            var controller = new OrderItemController(dataStore);

            //Act
            var actionResult = await controller.GetAll();

            //Assert
            var result = actionResult.Result as OkObjectResult;
            var returnOrderItems = result.Value as IEnumerable<OrderItem>;
            Assert.AreEqual(count, returnOrderItems.Count());    // Checks that the size of the returned list is the same as the original
        }

        /// <summary>
        /// Tests that GetOne method gets one entry with given Id
        /// public async Task<ActionResult<OrderItem>> GetOne(int Id)
        /// </summary>
        /// <returns>OkObjectResult</returns>
        [Test]
        public async Task GetOne_Gets_Same_ID()
        {
            //Arrange
            int Id = 1;
            var fakeOrderItem = A.Fake<OrderItem>();
            fakeOrderItem.MerchandiseOrderId = Id;
            fakeOrderItem.MerchandiseId = Id;
            var fakeOrderItem2 = A.Fake<OrderItem>();
            fakeOrderItem2.MerchandiseOrderId = 2;
            fakeOrderItem2.MerchandiseId = 2;
            var dataStore = A.Fake<IOrderItemRepository>();
            A.CallTo(() => dataStore.ReadAsync(Id, Id)).Returns(Task.FromResult(fakeOrderItem));
            var controller = new OrderItemController(dataStore);

            //Act
            var actionResult = await controller.GetOne(Id, Id);

            //Assert
            var result = actionResult.Result as OkObjectResult;
            var returnOrderItem = result.Value;
            Assert.IsNotNull(returnOrderItem);   // Checks that returned entry is not null
            Assert.AreEqual(fakeOrderItem, result.Value);    // Checks that returned entry is the entry with given ID
        }

        /// <summary>
        /// Tests that Update method updates a given entry with passing status code
        /// public async Task<ActionResult<OrderItem>> Put(OrderItem Updated)
        /// </summary>
        /// <returns>NoContentResult</returns>
        [Test]
        public async Task Put_Updates_Entry()
        {
            //Arrange
            var fakeOrderItem = A.Dummy<OrderItem>();
            var dataStore = A.Fake<IOrderItemRepository>();
            A.CallTo(() => dataStore.UpdateAsync(0, 0, fakeOrderItem)).Returns(Task.FromResult(fakeOrderItem));
            var controller = new OrderItemController(dataStore);

            //Act
            var actionResult = await controller.Put(fakeOrderItem);

            //Assert
            var result = actionResult.Result as NoContentResult;
            Assert.IsNotNull(result);   // Checks that an entry is updated.
            Assert.IsInstanceOf<NoContentResult>(result);   // Checks that the result is of the correct type
            Assert.AreEqual(204, result.StatusCode);    // Checks that correct status code is given
        }

        /// <summary>
        /// Tests that Remove method deletes a given entry
        /// public async Task<ActionResult<OrderItem>> Remove(int Id)
        /// </summary>
        /// <returns>NoContentResult</returns>
        [Test]
        public async Task Remove_deletes_Entry()
        {
            //Arrange
            int Id = 1;
            var fakeOrderItem = A.Dummy<OrderItem>();
            var dataStore = A.Fake<IOrderItemRepository>();
            A.CallTo(() => dataStore.DeleteAsync(Id, Id)).Returns(Task.FromResult(fakeOrderItem));
            var controller = new OrderItemController(dataStore);

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
