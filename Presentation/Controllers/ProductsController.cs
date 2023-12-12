using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

public class ProductsController : BaseController
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Delete(int? id)
    {
        return View();
    }

    public IActionResult Details(int? id)
    {
        return View();
    }

    public IActionResult Edit(int? id)
    {
        return View();
    }
}