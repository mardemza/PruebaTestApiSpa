using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaApiSpa.Controllers;

namespace PruebaApiSpa.Web.Host.Controllers
{
    public class HomeController : PruebaApiSpaControllerBase
    {
        public IActionResult Index()
        {
            return Redirect("/swagger");
        }
    }
}
