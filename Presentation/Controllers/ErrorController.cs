/*
 * Author: Luis López
 * Website: https://github.com/luislopez-dev
 * Description: Training Project
 */

using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

public class ErrorController: BaseController
{
    public IActionResult NotFound()
    {
        return View();
    }
}