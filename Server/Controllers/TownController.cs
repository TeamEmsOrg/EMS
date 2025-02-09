using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers;

public class TownController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}