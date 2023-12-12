using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

public class InvoicesController : BaseController
{
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Delete(int? id)
    {
        return View();
    }
}