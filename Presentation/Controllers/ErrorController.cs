using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

public class ErrorController: BaseController
{
    public IActionResult NotFound()
    {
        return View();
    }
}