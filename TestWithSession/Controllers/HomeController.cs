using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestWithSession.Helpers;
using TestWithSession.Models;

namespace TestWithSession.Controllers
{
    public class HomeController : Controller
    {
        SessionData sessionData;

        public IActionResult Index()
        {
            sessionData = SessionHelpers.GetDetails(HttpContext.Session);
            if (string.IsNullOrEmpty(sessionData.ClientId))
            {
                sessionData.ClientId = "No ClientId";

                ASCIIEncoding encoding = new ASCIIEncoding();
                HttpContext.Session.Set("ClientId", encoding.GetBytes("ClientId-001"));
            }

            return View(sessionData);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
