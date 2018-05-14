using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestWithSession.Models;
using TestWithSession.Tests.Helpers;

namespace TestWithSession.Tests.Controllers.Home
{
    [TestClass]
    public class WhenUsingHomeControllerWithSession : WhenUsingHomeController
    {
        [TestMethod]
        public void Then_Url_Must_Be_CliendId()
        {
            mockSession = new MockHttpSession();
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            _controller.ControllerContext.HttpContext = mockHttpContext.Object;

            IActionResult view = _controller.Index();
            var viewResult = Xunit.Assert.IsType<ViewResult>(view);
            var result = view as ViewResult;
            var model = result.Model as SessionData;

            Assert.AreEqual("No ClientId", model.ClientId);
        }
    }
}
