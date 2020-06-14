using Popkov_60331.Controllers;
using Popkov_60331.Models;
using Popkov_60331.DAL;
using Moq;
using System.Web.Mvc;
using System.Web;
using System.Web.Routing;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Popkov_60331.Tests.Controllers
{
    /// <summary>
    /// Summary description for BookControllerTest
    /// </summary>
    [TestClass]
    public class BookControllerTest
    {
        public BookControllerTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void PagingTest()
        {
            // Arrange
            // Макет репозитория
            var mock = new Mock<IRepository<Book>>();
            mock.Setup(r => r.GetAll())
            .Returns(new List<Book> {
                new Book { BookId=1 },
                new Book { BookId=2 },
                new Book { BookId=3 },
                new Book { BookId=4 },
                new Book { BookId=5 },
            });
            // Создание объекта контроллера
            var controller = new BookController(mock.Object);

            // Макеты для получения HttpContext HttpRequest
            var request = new Mock<HttpRequestBase>();
            var httpContext = new Mock<HttpContextBase>();
            httpContext.Setup(h => h.Request).Returns(request.Object);

            // Создание контекста контроллера
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = httpContext.Object;
            // Act
            // Вызов метода List
            var view = controller.List(null, 2) as ViewResult;
            // Assert
            Assert.IsNotNull(view, "Представление не получено");
            Assert.IsNotNull(view.Model, "Модель не получена");
            PageListViewModel<Book> model = view.Model as PageListViewModel<Book>;
            Assert.AreEqual(2, model.Count);
            Assert.AreEqual(4, model[0].BookId);
            Assert.AreEqual(5, model[1].BookId);
        }

        [TestMethod]
        public void CategoryTest()
        {
            // Arrange
            // Макет репозитория
            var mock = new Mock<IRepository<Book>>();
            mock.Setup(r => r.GetAll())
            .Returns(new List<Book> {
                new Book { BookId=1, BookType="1" },
                new Book { BookId=2, BookType="2" },
                new Book { BookId=3, BookType="1" },
                new Book { BookId=4, BookType="2" },
                new Book { BookId=5, BookType="2" },
            });

            // Создание объекта контроллера
            var controller = new BookController(mock.Object);

            // Макеты для получения HttpContext HttpRequest
            var request = new Mock<HttpRequestBase>();
            var httpContext = new Mock<HttpContextBase>();
            httpContext.Setup(h => h.Request).Returns(request.Object);

            // Создание контекста контроллера
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = httpContext.Object;
            // Act
            // Вызов метода List
            var view = controller.List("1", 1) as ViewResult;
            // Assert
            Assert.IsNotNull(view, "Представление не получено");
            Assert.IsNotNull(view.Model, "Модель не получена");
            PageListViewModel<Book> model = view.Model as PageListViewModel<Book>;
            Assert.AreEqual(2, model.Count);
            Assert.AreEqual(1, model[0].BookId);
            Assert.AreEqual(3, model[1].BookId);
        }
    }
}
