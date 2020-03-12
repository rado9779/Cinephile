using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinephile.Web.Controllers
{
    public class ForumController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Rules()
        {
            return this.View();
        }
    }
}
