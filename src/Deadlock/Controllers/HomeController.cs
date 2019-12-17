using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Deadlock.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            var message = AsyncOperation().Result; 
            ViewBag.Message = message;
            return View();
        }

        private async Task<string> AsyncOperation()
        {
            await Task.Delay(1000);
            
             return "Your application description page.";
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}