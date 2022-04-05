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
    public class EmployeeTests
    {
        /// <summary>
        /// Tests that Create method creates a new entry.
        /// public async Task<ActionResult<Employee>> Post(Employee employee)
        /// </summary>
        /// <returns>CreatedAtActionResult</returns>
        [Test]
        public async Task Create_Adds_Revision()
        {
            //Arrange
            var fakeRevision = A.Dummy<Employee>();
            var dataStore = A.Fake<IEmployeeRepository>();
            A.CallTo(() => dataStore.CreateAsync(fakeRevision)).Returns(Task.FromResult(fakeRevision));
            var controller = new EmployeeController(dataStore);

            //Act
            var actionResult = await controller.Post(fakeRevision);

            //Assert
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsNotNull(result);   // Checks that an entry is created.
            Assert.AreEqual(0, result.RouteValues["Id"]);   // Checks that the Id of the entry is what was submitted.
        }

        /// <summary>
        /// Tests that GetAll method returns list of all entries
        /// public async Task<ActionResult<IEnumerable<Employee>>> GetAll()
        /// </summary>
        /// <returns>OkObjectResult</returns>
        [Test]
        public async Task GetAll_Returns_All_Values()
        {
            //Arrange
            int count = 3;
            var fakeRevisions = A.CollectionOfDummy<Employee>(count).AsEnumerable();
            var dataStore = A.Fake<IEmployeeRepository>();
            A.CallTo(() => dataStore.ReadAllAsync()).Returns(Task.FromResult(fakeRevisions));
            var controller = new EmployeeController(dataStore);

            //Act
            var actionResult = await controller.GetAll();

            //Assert
            var result = actionResult.Result as OkObjectResult;
            var returnRevisions = result.Value as IEnumerable<Employee>;
            Assert.AreEqual(count, returnRevisions.Count());    // Checks that the size of the returned list is the same as the original
        }

        /// <summary>
        /// Tests that GetOne method gets one entry with given Id
        /// public async Task<ActionResult<Employee>> GetOne(int id)
        /// </summary>
        /// <returns>OkObjectResult</returns>
        [Test]
        public async Task GetOne_Gets_Same_ID()
        {
            //Arrange
            int Id = 1;
            var fakeRevision = A.Fake<Employee>();
            fakeRevision.Id = Id;
            var fakeRevision2 = A.Fake<Employee>();
            fakeRevision2.Id = 2;
            var dataStore = A.Fake<IEmployeeRepository>();
            A.CallTo(() => dataStore.ReadAsync(Id)).Returns(Task.FromResult(fakeRevision));
            var controller = new EmployeeController(dataStore);

            //Act
            var actionResult = await controller.GetOne(Id);

            //Assert
            var result = actionResult.Result as OkObjectResult;
            var returnRevision = result.Value;
            Assert.IsNotNull(returnRevision);   // Checks that returned entry is not null
            Assert.AreEqual(fakeRevision, result.Value);    // Checks that returned entry is the entry with given ID
        }

        /// <summary>
        /// Tests that Update method updates a given entry with passing status code
        /// public async Task<ActionResult<Employee>> Put(Employee Updated)
        /// </summary>
        /// <returns>NoContentResult</returns>
        [Test]
        public async Task Put_Updates_Entry()
        {
            //Arrange
            var fakeRevision = A.Dummy<Employee>();
            var dataStore = A.Fake<IEmployeeRepository>();
            A.CallTo(() => dataStore.UpdateAsync(0, fakeRevision)).Returns(Task.FromResult(fakeRevision));
            var controller = new EmployeeController(dataStore);

            //Act
            var actionResult = await controller.Put(fakeRevision);

            //Assert
            var result = actionResult.Result as NoContentResult;
            Assert.IsNotNull(result);   // Checks that an entry is updated.
            Assert.IsInstanceOf<NoContentResult>(result);   // Checks that the result is of the correct type
            Assert.AreEqual(204, result.StatusCode);    // Checks that correct status code is given
        }

        /// <summary>
        /// Tests that Remove method deletes a given entry
        /// public async Task<ActionResult<Employee>> Remove(int id)
        /// </summary>
        /// <returns>NoContentResult</returns>
        [Test]
        public async Task Remove_deletes_Entry()
        {
            //Arrange
            int Id = 1;
            var fakeRevision = A.Dummy<Employee>();
            var dataStore = A.Fake<IEmployeeRepository>();
            A.CallTo(() => dataStore.DeleteAsync(Id)).Returns(Task.FromResult(fakeRevision));
            var controller = new EmployeeController(dataStore);

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