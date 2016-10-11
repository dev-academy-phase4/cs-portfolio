using System.Web.Mvc;

namespace Portfolio.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Keep in touch!";

            return View();
        }
    }
}