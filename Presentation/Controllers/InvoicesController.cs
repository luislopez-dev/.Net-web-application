using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

public class InvoicesController : BaseController
{
    public IActionResult Index()
    {
        return View();
    }
}