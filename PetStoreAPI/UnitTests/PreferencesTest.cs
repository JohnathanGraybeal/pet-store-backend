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
    public class PreferencesTest
    {
        /// <summary>
        /// Tests that Create method creates a new entry.
        /// public async Task<ActionResult<Preferences>> Post(Preferences preferences)
        /// </summary>
        /// <returns>CreatedAtActionResult</returns>
        [Test]
        public async Task Create_Adds_Preferences()
        {
            //Arrange
            var fakePreferences = A.Dummy<Preferences>();
            var dataStore = A.Fake<IPreferencesRepository>();
            A.CallTo(() => dataStore.CreateAsync(fakePreferences)).Returns(Task.FromResult(fakePreferences));
            var controller = new PreferencesController(dataStore);

            //Act
            var actionResult = await controller.Post(fakePreferences);

            //Assert
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsNotNull(result);   // Checks that an entry is created.
            Assert.AreEqual(0, result.RouteValues["KeyId"]);   // Checks that the Id of the entry is what was submitted.
        }

        /// <summary>
        /// Tests that GetAll method returns list of all entries
        /// public async Task<ActionResult<IEnumerable<Preferences>>> GetAll()
        /// </summary>
        /// <returns>OkObjectResult</returns>
        [Test]
        public async Task GetAll_Returns_All_Values()
        {
            //Arrange
            int count = 3;
            var fakePreferencess = A.CollectionOfDummy<Preferences>(count).AsEnumerable();
            var dataStore = A.Fake<IPreferencesRepository>();
            A.CallTo(() => dataStore.ReadAllAsync()).Returns(Task.FromResult(fakePreferencess));
            var controller = new PreferencesController(dataStore);

            //Act
            var actionResult = await controller.GetAll();

            //Assert
            var result = actionResult.Result as OkObjectResult;
            var returnPreferencess = result.Value as IEnumerable<Preferences>;
            Assert.AreEqual(count, returnPreferencess.Count());    // Checks that the size of the returned list is the same as the original
        }

        /// <summary>
        /// Tests that GetOne method gets one entry with given Id
        /// public async Task<ActionResult<Preferences>> GetOne(int Id)
        /// </summary>
        /// <returns>OkObjectResult</returns>
        [Test]
        public async Task GetOne_Gets_Same_ID()
        {
            //Arrange
            int Id = 1;
            var fakePreferences = A.Fake<Preferences>();
            fakePreferences.KeyId = Id;
            var fakePreferences2 = A.Fake<Preferences>();
            fakePreferences2.KeyId = 2;
            var dataStore = A.Fake<IPreferencesRepository>();
            A.CallTo(() => dataStore.ReadAsync(Id)).Returns(Task.FromResult(fakePreferences));
            var controller = new PreferencesController(dataStore);

            //Act
            var actionResult = await controller.GetOne(Id);

            //Assert
            var result = actionResult.Result as OkObjectResult;
            var returnPreferences = result.Value;
            Assert.IsNotNull(returnPreferences);   // Checks that returned entry is not null
            Assert.AreEqual(fakePreferences, result.Value);    // Checks that returned entry is the entry with given ID
        }

        /// <summary>
        /// Tests that Update method updates a given entry with passing status code
        /// public async Task<ActionResult<Preferences>> Put(Preferences Updated)
        /// </summary>
        /// <returns>NoContentResult</returns>
        [Test]
        public async Task Put_Updates_Entry()
        {
            //Arrange
            var fakePreferences = A.Dummy<Preferences>();
            var dataStore = A.Fake<IPreferencesRepository>();
            A.CallTo(() => dataStore.UpdateAsync(0, fakePreferences)).Returns(Task.FromResult(fakePreferences));
            var controller = new PreferencesController(dataStore);

            //Act
            var actionResult = await controller.Put(fakePreferences);

            //Assert
            var result = actionResult.Result as NoContentResult;
            Assert.IsNotNull(result);   // Checks that an entry is updated.
            Assert.IsInstanceOf<NoContentResult>(result);   // Checks that the result is of the correct type
            Assert.AreEqual(204, result.StatusCode);    // Checks that correct status code is given
        }

        /// <summary>
        /// Tests that Remove method deletes a given entry
        /// public async Task<ActionResult<Preferences>> Remove(int Id)
        /// </summary>
        /// <returns>NoContentResult</returns>
        [Test]
        public async Task Remove_deletes_Entry()
        {
            //Arrange
            int Id = 1;
            var fakePreferences = A.Dummy<Preferences>();
            var dataStore = A.Fake<IPreferencesRepository>();
            A.CallTo(() => dataStore.DeleteAsync(Id)).Returns(Task.FromResult(fakePreferences));
            var controller = new PreferencesController(dataStore);

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
