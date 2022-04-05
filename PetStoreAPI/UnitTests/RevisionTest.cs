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
    public class RevisionTests
    {
        /// <summary>
        /// Tests that Create method creates a new entry.
        /// public async Task<ActionResult<Revision>> Post(Revision revision)
        /// </summary>
        /// <returns>CreatedAtActionResult</returns>
        [Test]
        public async Task Create_Adds_Revision()
        {
            //Arrange
            var fakeRevision = A.Dummy<Revision>();
            var dataStore = A.Fake<IRevisionRepository>();
            A.CallTo(() => dataStore.CreateAsync(fakeRevision)).Returns(Task.FromResult(fakeRevision));
            var controller = new RevisionController(dataStore);

            //Act
            var actionResult = await controller.Post(fakeRevision);

            //Assert
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsNotNull(result);   // Checks that an entry is created.
            Assert.AreEqual(0, result.RouteValues["Id"]);   // Checks that the Id of the entry is what was submitted.
        }

        /// <summary>
        /// Tests that GetAll method returns list of all entries
        /// public async Task<ActionResult<IEnumerable<Revision>>> GetAll()
        /// </summary>
        /// <returns>OkObjectResult</returns>
        [Test]
        public async Task GetAll_Returns_All_Values()
        {
            //Arrange
            int count = 3;
            var fakeRevisions = A.CollectionOfDummy<Revision>(count).AsEnumerable();
            var dataStore = A.Fake<IRevisionRepository>();
            A.CallTo(() => dataStore.ReadAllAsync()).Returns(Task.FromResult(fakeRevisions));
            var controller = new RevisionController(dataStore);

            //Act
            var actionResult = await controller.GetAll();

            //Assert
            var result = actionResult.Result as OkObjectResult;
            var returnRevisions = result.Value as IEnumerable<Revision>;
            Assert.AreEqual(count, returnRevisions.Count());    // Checks that the size of the returned list is the same as the original
        }

        /// <summary>
        /// Tests that GetOne method gets one entry with given Id
        /// public async Task<ActionResult<Revision>> GetOne(int Id)
        /// </summary>
        /// <returns>OkObjectResult</returns>
        [Test]
        public async Task GetOne_Gets_Same_ID()
        {
            //Arrange
            int Id = 1;
            var fakeRevision = A.Fake<Revision>();
            fakeRevision.Id = Id;
            var fakeRevision2 = A.Fake<Revision>();
            fakeRevision2.Id = 2;
            var dataStore = A.Fake<IRevisionRepository>();
            A.CallTo(() => dataStore.ReadAsync(Id)).Returns(Task.FromResult(fakeRevision));
            var controller = new RevisionController(dataStore);

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
        /// public async Task<ActionResult<Revision>> Put(Revision Updated)
        /// </summary>
        /// <returns>NoContentResult</returns>
        [Test]
        public async Task Put_Updates_Entry()
        {
            //Arrange
            var fakeRevision = A.Dummy<Revision>();
            var dataStore = A.Fake<IRevisionRepository>();
            A.CallTo(() => dataStore.UpdateAsync(0, fakeRevision)).Returns(Task.FromResult(fakeRevision));
            var controller = new RevisionController(dataStore);

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
        /// public async Task<ActionResult<Revision>> Remove(int Id)
        /// </summary>
        /// <returns>NoContentResult</returns>
        [Test]
        public async Task Remove_deletes_Entry()
        {
            //Arrange
            int Id = 1;
            var fakeRevision = A.Dummy<Revision>();
            var dataStore = A.Fake<IRevisionRepository>();
            A.CallTo(() => dataStore.DeleteAsync(Id)).Returns(Task.FromResult(fakeRevision));
            var controller = new RevisionController(dataStore);

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