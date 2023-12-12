using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

public class ProductsController : BaseController
{
    public IActionResult Index()
    {
        return View();
    }
}