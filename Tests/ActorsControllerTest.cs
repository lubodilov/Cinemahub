using Cinemahub_Official.Controllers;
using Cinemahub_Official.Data;
using Cinemahub_Official.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;

namespace Tests
{
    public class Tests
    {
        private ApplicationDbContext context;
        private ActorsController actorsController;
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                           .UseInMemoryDatabase("TestDb").Options;

            this.context = new ApplicationDbContext(options);
            actorsController = new ActorsController(this.context);
        }


        [TearDown]
        public void TearDown()
        {
            this.context.Database.EnsureDeleted();
        }


        [Test]
        public void TestGetAll()
        {
            Actor actor1 = Create(1, "Actor Name 1");
            Actor actor2 = Create(2, "Product Name 2");
            Actor actor3 = Create(3, "Product Name 3");

            User user = new User();
            productService.Create(product, user);
            productService.Create(product2, user);
            productService.Create(product3, user);

            List<ProductDTO> productDTOs = productService.GetAll();

            Assert.AreEqual(3, productDTOs.Count);
            Assert.AreEqual("Product Name", productDTOs[0].Name);
        }

        [Test]
        public void TestGetById()
        {
            Actor actor = Create(1, "Product Name");
            User user = new User();
            ActorsController.Create(actor, user);

            Actor dbProduct = ActorsController.Details(1);

            Assert.AreEqual(dbProduct.Name, "Product Name");
        }

        [Test]
        public void TestCreate()
        {
            Actor actor = Create(1, "Product Name");
            User user = new User();

            actorsController.Create(actor, user);

            Actor dbProduct = context.Actor.FirstOrDefault();

            Assert.NotNull(dbProduct);
        }

        [Test]
        public void TestEdit()
        {
            ActorsController actorsController = new ActorsController(this.context);

            Actor product = new Actor();
            product.Id = 1;
            product.Name = "Product Name";
            User user = new User();

            actorsController.Create(product, user);

            Actor editProduct = new Actor();

            editProduct.Id = 1;
            editProduct.Name = "asd";

            actorsController.Edit(editProduct);

            Actor dbProduct = context.Actor.FirstOrDefault(x => x.Id == 1);

            Assert.NotNull(dbProduct);
            Assert.AreEqual(dbProduct.Name, "asd");
        }

        [Test]
        public void TestDelete()
        {
            ActorsController actorsController = new ActorsController(this.context);

            Actor actor = new Actor();
            actor.Id = 1;
            actor.Name = "Product Name";
            User user = new User();

            actorsController.Create(actor, user);

            actorsController.Delete(1);

            Actor dbProduct = context.Actor.FirstOrDefault(x => x.Id == 1);
            Assert.Null(dbProduct);
        }

        private Actor Create(int id, string name)
        {
            Actor actor = new Actor();
            actor.Id = id;
            actor.Name = name;

            return actor;
        }
    }
}