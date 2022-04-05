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
    public class MerchandiseOrderTest
    {
        /// <summary>
        /// Tests that Create method creates a new entry.
        /// public async Task<ActionResult<MerchandiseOrder>> Post(MerchandiseOrder merchandiseOrder)
        /// </summary>
        /// <returns>CreatedAtActionResult</returns>
        [Test]
        public async Task Create_Adds_MerchandiseOrder()
        {
            //Arrange
            var fakeMerchandiseOrder = A.Dummy<MerchandiseOrder>();
            var dataStore = A.Fake<IMerchandiseOrderRepository>();
            A.CallTo(() => dataStore.CreateAsync(fakeMerchandiseOrder)).Returns(Task.FromResult(fakeMerchandiseOrder));
            var controller = new MerchandiseOrderController(dataStore);

            //Act
            var actionResult = await controller.Post(fakeMerchandiseOrder);

            //Assert
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsNotNull(result);   // Checks that an entry is created.
            Assert.AreEqual(0, result.RouteValues["PONumber"]);   // Checks that the Id of the entry is what was submitted.
        }

        /// <summary>
        /// Tests that GetAll method returns list of all entries
        /// public async Task<ActionResult<IEnumerable<MerchandiseOrder>>> GetAll()
        /// </summary>
        /// <returns>OkObjectResult</returns>
        [Test]
        public async Task GetAll_Returns_All_Values()
        {
            //Arrange
            int count = 3;
            var fakeMerchandiseOrders = A.CollectionOfDummy<MerchandiseOrder>(count).AsEnumerable();
            var dataStore = A.Fake<IMerchandiseOrderRepository>();
            A.CallTo(() => dataStore.ReadAllAsync()).Returns(Task.FromResult(fakeMerchandiseOrders));
            var controller = new MerchandiseOrderController(dataStore);

            //Act
            var actionResult = await controller.GetAll();

            //Assert
            var result = actionResult.Result as OkObjectResult;
            var returnMerchandiseOrders = result.Value as IEnumerable<MerchandiseOrder>;
            Assert.AreEqual(count, returnMerchandiseOrders.Count());    // Checks that the size of the returned list is the same as the original
        }

        /// <summary>
        /// Tests that GetOne method gets one entry with given Id
        /// public async Task<ActionResult<MerchandiseOrder>> GetOne(int Id)
        /// </summary>
        /// <returns>OkObjectResult</returns>
        [Test]
        public async Task GetOne_Gets_Same_ID()
        {
            //Arrange
            int Id = 1;
            var fakeMerchandiseOrder = A.Fake<MerchandiseOrder>();
            fakeMerchandiseOrder.Id = Id;
            var fakeMerchandiseOrder2 = A.Fake<MerchandiseOrder>();
            fakeMerchandiseOrder2.Id = 2;
            var dataStore = A.Fake<IMerchandiseOrderRepository>();
            A.CallTo(() => dataStore.ReadAsync(Id)).Returns(Task.FromResult(fakeMerchandiseOrder));
            var controller = new MerchandiseOrderController(dataStore);

            //Act
            var actionResult = await controller.GetOne(Id);

            //Assert
            var result = actionResult.Result as OkObjectResult;
            var returnMerchandiseOrder = result.Value;
            Assert.IsNotNull(returnMerchandiseOrder);   // Checks that returned entry is not null
            Assert.AreEqual(fakeMerchandiseOrder, result.Value);    // Checks that returned entry is the entry with given ID
        }

        /// <summary>
        /// Tests that Update method updates a given entry with passing status code
        /// public async Task<ActionResult<MerchandiseOrder>> Put(MerchandiseOrder Updated)
        /// </summary>
        /// <returns>NoContentResult</returns>
        [Test]
        public async Task Put_Updates_Entry()
        {
            //Arrange
            var fakeMerchandiseOrder = A.Dummy<MerchandiseOrder>();
            var dataStore = A.Fake<IMerchandiseOrderRepository>();
            A.CallTo(() => dataStore.UpdateAsync(0, fakeMerchandiseOrder)).Returns(Task.FromResult(fakeMerchandiseOrder));
            var controller = new MerchandiseOrderController(dataStore);

            //Act
            var actionResult = await controller.Put(fakeMerchandiseOrder);

            //Assert
            var result = actionResult.Result as NoContentResult;
            Assert.IsNotNull(result);   // Checks that an entry is updated.
            Assert.IsInstanceOf<NoContentResult>(result);   // Checks that the result is of the correct type
            Assert.AreEqual(204, result.StatusCode);    // Checks that correct status code is given
        }

        /// <summary>
        /// Tests that Remove method deletes a given entry
        /// public async Task<ActionResult<MerchandiseOrder>> Remove(int Id)
        /// </summary>
        /// <returns>NoContentResult</returns>
        [Test]
        public async Task Remove_deletes_Entry()
        {
            //Arrange
            int Id = 1;
            var fakeMerchandiseOrder = A.Dummy<MerchandiseOrder>();
            var dataStore = A.Fake<IMerchandiseOrderRepository>();
            A.CallTo(() => dataStore.DeleteAsync(Id)).Returns(Task.FromResult(fakeMerchandiseOrder));
            var controller = new MerchandiseOrderController(dataStore);

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
