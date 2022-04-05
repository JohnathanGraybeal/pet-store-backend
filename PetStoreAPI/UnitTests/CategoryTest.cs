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
    public class CategoryTest
    {
        /// <summary>
        /// Tests that Create method creates a new entry.
        /// public async Task<ActionResult<Category>> Post(Category category)
        /// </summary>
        /// <returns>CreatedAtActionResult</returns>
        [Test]
        public async Task Create_Adds_Category()
        {
            //Arrange
            var fakeCategory = A.Dummy<Category>();
            var dataStore = A.Fake<ICategoryRepository>();
            A.CallTo(() => dataStore.CreateAsync(fakeCategory)).Returns(Task.FromResult(fakeCategory));
            var controller = new CategoryController(dataStore);

            //Act
            var actionResult = await controller.Post(fakeCategory);

            //Assert
            var result = actionResult.Result as CreatedAtActionResult;
            Assert.IsNotNull(result);   // Checks that an entry is created.
            Assert.AreEqual(null, result.RouteValues["Category"]);   // Checks that the Category of the entry is what was submitted.
        }

        /// <summary>
        /// Tests that GetAll method returns list of all entries
        /// public async Task<ActionResult<IEnumerable<Category>>> GetAll()
        /// </summary>
        /// <returns>OkObjectResult</returns>
        [Test]
        public async Task GetAll_Returns_All_Values()
        {
            //Arrange
            int count = 3;
            var fakeCategories = A.CollectionOfDummy<Category>(count).AsEnumerable();
            var dataStore = A.Fake<ICategoryRepository>();
            A.CallTo(() => dataStore.ReadAllAsync()).Returns(Task.FromResult(fakeCategories));
            var controller = new CategoryController(dataStore);

            //Act
            var actionResult = await controller.GetAll();

            //Assert
            var result = actionResult.Result as OkObjectResult;
            var returnCategories = result.Value as IEnumerable<Category>;
            Assert.AreEqual(count, returnCategories.Count());    // Checks that the size of the returned list is the same as the original
        }

        /// <summary>
        /// Tests that GetOne method gets one entry with given Id
        /// public async Task<ActionResult<Category>> GetOne(int Id)
        /// </summary>
        /// <returns>OkObjectResult</returns>
        /*[Test]
        public async Task GetOne_Gets_Same_ID()
        {
            //Arrange
            string AnimalCategory = "Other";
            var fakeCategory = A.Fake<Category>();
            fakeCategory.AnimalCategory = AnimalCategory;
            var fakeCategory2 = A.Fake<Category>();
            fakeCategory2.AnimalCategory = "Dog";
            var dataStore = A.Fake<ICategoryRepository>();
            A.CallTo(() => dataStore.ReadAsync(AnimalCategory)).Returns(Task.FromResult(AnimalCategory));
            var controller = new CategoryController(dataStore);

            //Act
            var actionResult = await controller.GetOne(AnimalCategory);

            //Assert
            var result = actionResult.Result as OkObjectResult;
            var returnCategory = result.Value;
            Assert.IsNotNull(returnCategory);   // Checks that returned entry is not null
            Assert.AreEqual(fakeCategory, result.Value);    // Checks that returned entry is the entry with given AnimalCategory
        }*/

        /// <summary>
        /// Tests that Update method updates a given entry with passing status code
        /// public async Task<ActionResult<Category>> Put(Category Updated)
        /// </summary>
        /// <returns>NoContentResult</returns>
        [Test]
        public async Task Put_Updates_Entry()
        {
            //Arrange
            var fakeCategory = A.Dummy<Category>();
            var dataStore = A.Fake<ICategoryRepository>();
            A.CallTo(() => dataStore.UpdateAsync(fakeCategory)).Returns(Task.FromResult(fakeCategory));
            var controller = new CategoryController(dataStore);

            //Act
            var actionResult = await controller.Put(fakeCategory);

            //Assert
            var result = actionResult.Result as NoContentResult;
            Assert.IsNotNull(result);   // Checks that an entry is updated.
            Assert.IsInstanceOf<NoContentResult>(result);   // Checks that the result is of the correct type
            Assert.AreEqual(204, result.StatusCode);    // Checks that correct status code is given
        }

        /// <summary>
        /// Tests that Remove method deletes a given entry
        /// public async Task<ActionResult<Category>> Remove(int Id)
        /// </summary>
        /// <returns>NoContentResult</returns>
        [Test]
        public async Task Remove_deletes_Entry()
        {
            //Arrange
            string AnimalCategory = "Other";
            var fakeCategory = A.Dummy<Category>();
            var dataStore = A.Fake<ICategoryRepository>();
            A.CallTo(() => dataStore.DeleteAsync(AnimalCategory)).Returns(Task.FromResult(fakeCategory));
            var controller = new CategoryController(dataStore);

            //Act
            var actionResult = await controller.Remove(AnimalCategory);

            //Assert
            var result = actionResult.Result as NoContentResult;
            Assert.IsNotNull(result);   // Checks that an entry is deleted.
            Assert.IsInstanceOf<NoContentResult>(result);   // Checks that the result is of the correct type
            Assert.AreEqual(204, result.StatusCode);    // Checks that correct status code is given
        }
    }
}
