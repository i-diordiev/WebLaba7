using Microsoft.AspNetCore.Mvc;

namespace WebLaba7.Controllers
{
    public class ReceiptController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}