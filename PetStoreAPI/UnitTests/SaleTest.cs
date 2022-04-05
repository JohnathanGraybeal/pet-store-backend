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
    class SaleTest
    {
        /// <summary>
        /// Tests that Create method creates a new entry.
        /// public async Task<ActionResult<SaleItem>> Post(SaleItem saleItem)
        /// </summary>
        /// <returns>CreatedAtActionResult</returns>
        [Test]
        public async Task Create_Adds_SaleItem()
        {
            //Arrange
            var fakeSaleItem = A.Dummy<SaleItem>();
            var dataStore = A.Fake<ISaleItemRepository>();
            A.CallTo(() => dataStore.CreateAsync(fakeSaleItem)).Returns(Task.FromResult(fakeSaleItem));
            var controller = new SaleItemController(dataStore);

            //Act
            var actionResult = await controller.Post(fakeSaleItem);

            //Assert
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsNotNull(result);   // Checks that an entry is created.
            Assert.AreEqual(0, result.RouteValues["Id"]);   // Checks that the Id of the entry is what was submitted.
        }

        /// <summary>
        /// Tests that GetAll method returns list of all entries
        /// public async Task<ActionResult<IEnumerable<SaleItem>>> GetAll()
        /// </summary>
        /// <returns>OkObjectResult</returns>
        [Test]
        public async Task GetAll_Returns_All_Values()
        {
            //Arrange
            int count = 3;
            var fakeSaleItems = A.CollectionOfDummy<SaleItem>(count).AsEnumerable();
            var dataStore = A.Fake<ISaleItemRepository>();
            A.CallTo(() => dataStore.ReadAllAsync()).Returns(Task.FromResult(fakeSaleItems));
            var controller = new SaleItemController(dataStore);

            //Act
            var actionResult = await controller.GetAll();

            //Assert
            var result = actionResult.Result as OkObjectResult;
            var returnSaleItems = result.Value as IEnumerable<SaleItem>;
            Assert.AreEqual(count, returnSaleItems.Count());    // Checks that the size of the returned list is the same as the original
        }

        /// <summary>
        /// Tests that GetOne method gets one entry with given Id
        /// public async Task<ActionResult<SaleItem>> GetOne(int Id)
        /// </summary>
        /// <returns>OkObjectResult</returns>
        [Test]
        public async Task GetOne_Gets_Same_ID()
        {
            //Arrange
            int Id = 1;
            var fakeSaleItem = A.Fake<SaleItem>();
            fakeSaleItem.SaleId = Id;
            var fakeSaleItem2 = A.Fake<SaleItem>();
            fakeSaleItem2.SaleId = 2;
            var dataStore = A.Fake<ISaleItemRepository>();
            A.CallTo(() => dataStore.ReadAsync(Id, Id)).Returns(Task.FromResult(fakeSaleItem));
            var controller = new SaleItemController(dataStore);

            //Act
            var actionResult = await controller.GetOne(Id, Id);

            //Assert
            var result = actionResult.Result as OkObjectResult;
            var returnSaleItem = result.Value;
            Assert.IsNotNull(returnSaleItem);   // Checks that returned entry is not null
            Assert.AreEqual(fakeSaleItem, result.Value);    // Checks that returned entry is the entry with given ID
        }

        /// <summary>
        /// Tests that Update method updates a given entry with passing status code
        /// public async Task<ActionResult<SaleItem>> Put(SaleItem Updated)
        /// </summary>
        /// <returns>NoContentResult</returns>
        [Test]
        public async Task Put_Updates_Entry()
        {
            //Arrange
            var fakeSaleItem = A.Dummy<SaleItem>();
            var dataStore = A.Fake<ISaleItemRepository>();
            A.CallTo(() => dataStore.UpdateAsync(0, 0, fakeSaleItem)).Returns(Task.FromResult(fakeSaleItem));
            var controller = new SaleItemController(dataStore);

            //Act
            var actionResult = await controller.Put(fakeSaleItem);

            //Assert
            var result = actionResult.Result as NoContentResult;
            Assert.IsNotNull(result);   // Checks that an entry is updated.
            Assert.IsInstanceOf<NoContentResult>(result);   // Checks that the result is of the correct type
            Assert.AreEqual(204, result.StatusCode);    // Checks that correct status code is given
        }

        /// <summary>
        /// Tests that Remove method deletes a given entry
        /// public async Task<ActionResult<SaleItem>> Remove(int Id)
        /// </summary>
        /// <returns>NoContentResult</returns>
        [Test]
        public async Task Remove_deletes_Entry()
        {
            //Arrange
            int Id = 1;
            var fakeSaleItem = A.Dummy<SaleItem>();
            var dataStore = A.Fake<ISaleItemRepository>();
            A.CallTo(() => dataStore.DeleteAsync(Id, Id)).Returns(Task.FromResult(fakeSaleItem));
            var controller = new SaleItemController(dataStore);

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
