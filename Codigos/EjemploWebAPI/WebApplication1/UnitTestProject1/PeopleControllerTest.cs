using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Controllers;
using Logic;
using Logic.Interface;
using Domain;
using Moq;
using System.Collections.Generic;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class PeopleControllerTest
    {
        [TestMethod]
        public void PostTest()
        {
            IPersonLogic logic = new PersonLogic();
            PeopleController controller = new PeopleController(logic);
            Person person = new Person()
            {
                Id = 1,
                Name = "Mario",
                Age = 88
            };

            var result = controller.Post(person);
            var okResult = result as CreatedResult;
            var statusCode = okResult.StatusCode;

            Assert.AreEqual(201, statusCode);
        }
        [TestMethod]
        public void GetListTest()
        {
            var logicMock = new Mock<IPersonLogic>(MockBehavior.Strict);
            PeopleController controller = new PeopleController(logicMock.Object);
            Person person = new Person()
            {
                Id = 1,
                Name = "Mario",
                Age = 88
            };

            logicMock.Setup(personLogic => personLogic.GetAll()).Returns(new List<Person>() { person });

            var result = controller.Get();
            var okResult = result as OkObjectResult;
            var value = okResult.Value as List<Person>;

            logicMock.VerifyAll();
            Assert.AreEqual(1, value.Count);
        }
        [TestMethod]
        public void GetById()
        {
            var logicMock = new Mock<IPersonLogic>(MockBehavior.Strict);
            PeopleController controller = new PeopleController(logicMock.Object);
            
            Person person = new Person()
            {
                Id = 1,
                Name = "Mario",
                Age = 88
            };
            logicMock.Setup(personLogic => personLogic.GetById(It.IsAny<int>())).Returns(person);

            var result = controller.GetById(It.IsAny<int>());
            var okResult = result as OkObjectResult;
            var statusCode = okResult.StatusCode;

            logicMock.VerifyAll();
            Assert.AreEqual(200, statusCode);
        }
        [TestMethod]
        public void GetByIdNotExist()
        {
            var logicMock = new Mock<IPersonLogic>(MockBehavior.Strict);
            PeopleController controller = new PeopleController(logicMock.Object);

            Person nullperson = null;
            logicMock.Setup(personLogic => personLogic.GetById(It.IsAny<int>())).Returns(nullperson);

            var result = controller.GetById(It.IsAny<int>());
            var okResult = result as NotFoundObjectResult;
            var statusCode = okResult.StatusCode;

            logicMock.VerifyAll();
            Assert.AreEqual(404, statusCode);
        }
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void GetByIdWithException()
        {
            var logicMock = new Mock<IPersonLogic>(MockBehavior.Strict);
            PeopleController controller = new PeopleController(logicMock.Object);

            logicMock.Setup(personLogic => personLogic.GetById(It.IsAny<int>())).Throws(new ArgumentException());

            var result = controller.GetById(It.IsAny<int>());

            logicMock.VerifyAll();
        }
    }
}
