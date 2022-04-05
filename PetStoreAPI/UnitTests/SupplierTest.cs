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
    class SupplierTest
    {
        /// <summary>
        /// Tests that Create method creates a new entry.
        /// public async Task<ActionResult<Supplier>> Post(Supplier supplier)
        /// </summary>
        /// <returns>CreatedAtActionResult</returns>
        [Test]
        public async Task Create_Adds_Supplier()
        {
            //Arrange
            var fakeSupplier = A.Dummy<Supplier>();
            var dataStore = A.Fake<ISupplierRepository>();
            A.CallTo(() => dataStore.CreateAsync(fakeSupplier)).Returns(Task.FromResult(fakeSupplier));
            var controller = new SupplierController(dataStore);

            //Act
            var actionResult = await controller.Post(fakeSupplier);

            //Assert
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsNotNull(result);   // Checks that an entry is created.
            Assert.AreEqual(0, result.RouteValues["Id"]);   // Checks that the Id of the entry is what was submitted.
        }

        /// <summary>
        /// Tests that GetAll method returns list of all entries
        /// public async Task<ActionResult<IEnumerable<Supplier>>> GetAll()
        /// </summary>
        /// <returns>OkObjectResult</returns>
        [Test]
        public async Task GetAll_Returns_All_Values()
        {
            //Arrange
            int count = 3;
            var fakeSuppliers = A.CollectionOfDummy<Supplier>(count).AsEnumerable();
            var dataStore = A.Fake<ISupplierRepository>();
            A.CallTo(() => dataStore.ReadAllAsync()).Returns(Task.FromResult(fakeSuppliers));
            var controller = new SupplierController(dataStore);

            //Act
            var actionResult = await controller.GetAll();

            //Assert
            var result = actionResult.Result as OkObjectResult;
            var returnSuppliers = result.Value as IEnumerable<Supplier>;
            Assert.AreEqual(count, returnSuppliers.Count());    // Checks that the size of the returned list is the same as the original
        }

        /// <summary>
        /// Tests that GetOne method gets one entry with given Id
        /// public async Task<ActionResult<Supplier>> GetOne(int Id)
        /// </summary>
        /// <returns>OkObjectResult</returns>
        [Test]
        public async Task GetOne_Gets_Same_ID()
        {
            //Arrange
            int Id = 1;
            var fakeSupplier = A.Fake<Supplier>();
            fakeSupplier.Id = Id;
            var fakeSupplier2 = A.Fake<Supplier>();
            fakeSupplier2.Id = 2;
            var dataStore = A.Fake<ISupplierRepository>();
            A.CallTo(() => dataStore.ReadAsync(Id)).Returns(Task.FromResult(fakeSupplier));
            var controller = new SupplierController(dataStore);

            //Act
            var actionResult = await controller.GetOne(Id);

            //Assert
            var result = actionResult.Result as OkObjectResult;
            var returnSupplier = result.Value;
            Assert.IsNotNull(returnSupplier);   // Checks that returned entry is not null
            Assert.AreEqual(fakeSupplier, result.Value);    // Checks that returned entry is the entry with given ID
        }

        /// <summary>
        /// Tests that Update method updates a given entry with passing status code
        /// public async Task<ActionResult<Supplier>> Put(Supplier Updated)
        /// </summary>
        /// <returns>NoContentResult</returns>
        [Test]
        public async Task Put_Updates_Entry()
        {
            //Arrange
            var fakeSupplier = A.Dummy<Supplier>();
            var dataStore = A.Fake<ISupplierRepository>();
            A.CallTo(() => dataStore.UpdateAsync(0, fakeSupplier)).Returns(Task.FromResult(fakeSupplier));
            var controller = new SupplierController(dataStore);

            //Act
            var actionResult = await controller.Put(fakeSupplier);

            //Assert
            var result = actionResult.Result as NoContentResult;
            Assert.IsNotNull(result);   // Checks that an entry is updated.
            Assert.IsInstanceOf<NoContentResult>(result);   // Checks that the result is of the correct type
            Assert.AreEqual(204, result.StatusCode);    // Checks that correct status code is given
        }

        /// <summary>
        /// Tests that Remove method deletes a given entry
        /// public async Task<ActionResult<Supplier>> Remove(int Id)
        /// </summary>
        /// <returns>NoContentResult</returns>
        [Test]
        public async Task Remove_deletes_Entry()
        {
            //Arrange
            int Id = 1;
            var fakeSupplier = A.Dummy<Supplier>();
            var dataStore = A.Fake<ISupplierRepository>();
            A.CallTo(() => dataStore.DeleteAsync(Id)).Returns(Task.FromResult(fakeSupplier));
            var controller = new SupplierController(dataStore);

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
