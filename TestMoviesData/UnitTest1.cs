using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Cinemahub_Official.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cinemahub_Official.Data;
using Cinemahub_Official.Models;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Web.Mvc;
using Cinemahub_Official.Controllers;
using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace TestMoviesData
{
    [TestClass]
    public class UnitTest1
    {
        private Application1DbContext context;
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<Application1DbContext>().UseInMemoryDatabase("Junit").Options;
            this.context = new Application1DbContext(options);
        }
        [TestMethod]
        public void TestDetailsViewData()
        {

            MoviesController controller = new MoviesController(this.context);
            Microsoft.AspNetCore.Mvc.ViewResult result = controller.Create();

            Movies model = new Movies();

            model.Id = 5;
            model.Name = "Test";
            model.Director = "Test Name";
            model.Duration = 120;
            model.ReleaseDate = new DateTime();

            result.ViewData.Model = model;

            var result1 = controller.Details(4);



            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(5, 10);
            
        }
    }
}
