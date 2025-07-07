using Microsoft.AspNetCore.Mvc;

namespace CRUD.Interfaces.WebApp.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
