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
    public class CityTest
    {
        /// <summary>
        /// Tests that Create method creates a new entry.
        /// public async Task<ActionResult<City>> Post(City city)
        /// </summary>
        /// <returns>CreatedAtActionResult</returns>
        [Test]
        public async Task Create_Adds_City()
        {
            //Arrange
            var fakeCity = A.Dummy<City>();
            var dataStore = A.Fake<ICityRepository>();
            A.CallTo(() => dataStore.CreateAsync(fakeCity)).Returns(Task.FromResult(fakeCity));
            var controller = new CityController(dataStore);

            //Act
            var actionResult = await controller.Post(fakeCity);

            //Assert
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsNotNull(result);   // Checks that an entry is created.
            Assert.AreEqual(0, result.RouteValues["CityId"]);   // Checks that the CityId of the entry is what was submitted.
        }

        /// <summary>
        /// Tests that GetAll method returns list of all entries
        /// public async Task<ActionResult<IEnumerable<City>>> GetAll()
        /// </summary>
        /// <returns>OkObjectResult</returns>
        [Test]
        public async Task GetAll_Returns_All_Values()
        {
            //Arrange
            int count = 3;
            var fakeCities = A.CollectionOfDummy<City>(count).AsEnumerable();
            var dataStore = A.Fake<ICityRepository>();
            A.CallTo(() => dataStore.ReadAllAsync()).Returns(Task.FromResult(fakeCities));
            var controller = new CityController(dataStore);

            //Act
            var actionResult = await controller.GetAll();

            //Assert
            var result = actionResult.Result as OkObjectResult;
            var returnCities = result.Value as IEnumerable<City>;
            Assert.AreEqual(count, returnCities.Count());    // Checks that the size of the returned list is the same as the original
        }

        /// <summary>
        /// Tests that GetOne method gets one entry with given Id
        /// public async Task<ActionResult<City>> GetOne(int Id)
        /// </summary>
        /// <returns>OkObjectResult</returns>
        [Test]
        public async Task GetOne_Gets_Same_ID()
        {
            //Arrange
            int Id = 1;
            var faceCity = A.Fake<City>();
            faceCity.Id = Id;
            var fakeCity2 = A.Fake<City>();
            fakeCity2.Id = 2;
            var dataStore = A.Fake<ICityRepository>();
            A.CallTo(() => dataStore.ReadAsync(Id)).Returns(Task.FromResult(faceCity));
            var controller = new CityController(dataStore);

            //Act
            var actionResult = await controller.GetOne(Id);

            //Assert
            var result = actionResult.Result as OkObjectResult;
            var returnCity = result.Value;
            Assert.IsNotNull(returnCity);   // Checks that returned entry is not null
            Assert.AreEqual(faceCity, result.Value);    // Checks that returned entry is the entry with given ID
        }

        /// <summary>
        /// Tests that Update method updates a given entry with passing status code
        /// public async Task<ActionResult<City>> Put(City Updated)
        /// </summary>
        /// <returns>NoContentResult</returns>
        [Test]
        public async Task Put_Updates_Entry()
        {
            //Arrange
            var fakeCity = A.Dummy<City>();
            var dataStore = A.Fake<ICityRepository>();
            A.CallTo(() => dataStore.UpdateAsync(0, fakeCity)).Returns(Task.FromResult(fakeCity));
            var controller = new CityController(dataStore);

            //Act
            var actionResult = await controller.Put(fakeCity);

            //Assert
            var result = actionResult.Result as NoContentResult;
            Assert.IsNotNull(result);   // Checks that an entry is updated.
            Assert.IsInstanceOf<NoContentResult>(result);   // Checks that the result is of the correct type
            Assert.AreEqual(204, result.StatusCode);    // Checks that correct status code is given
        }

        /// <summary>
        /// Tests that Remove method deletes a given entry
        /// public async Task<ActionResult<City>> Remove(int Id)
        /// </summary>
        /// <returns>NoContentResult</returns>
        [Test]
        public async Task Remove_deletes_Entry()
        {
            //Arrange
            int Id = 1;
            var fakeCity = A.Dummy<City>();
            var dataStore = A.Fake<ICityRepository>();
            A.CallTo(() => dataStore.DeleteAsync(Id)).Returns(Task.FromResult(fakeCity));
            var controller = new CityController(dataStore);

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
