using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TestWithSession.Controllers;
using TestWithSession.Tests.Helpers;

namespace TestWithSession.Tests.Controllers.Home
{
    [TestClass]
    public class WhenUsingHomeController
    {
        protected Mock<HttpContext> mockHttpContext;
        protected Mock<ITempDataDictionary> tempDataMock;
        protected MockHttpSession mockSession;
        protected HomeController _controller;

        [TestInitialize]
        public void SetUp()
        {
            When_Using_Home_Controller();
        }

        public virtual void When_Using_Home_Controller()
        {
            mockHttpContext = new Mock<HttpContext>();

            mockSession = new MockHttpSession();
            tempDataMock = new Mock<ITempDataDictionary>();

            _controller = new HomeController();
            _controller.TempData = tempDataMock.Object;
        }
    }
}