using Application.Abstractions;
using Business.Exceptions.Product;
using Business.Exceptions.Product.Exceptions.DatabaseExceptions;
using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

public class ProductsController : BaseController
{
    private readonly IProductService _productService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(IProductService productService, IUnitOfWork unitOfWork, ILogger<ProductsController> logger)
    {
        _productService = productService;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
       
        var products = await _productService
                .GetProductsPaginatedAsync(cancellationToken);
        return View(products);
    }
    
    public ActionResult Create()
    {
        return View();
    }
    
    public async Task<IActionResult> Search(string productName, CancellationToken cancellationToken)
    {
        var products = await
            _productService
                .GetProductsByNamePaginatedAsync(productName, cancellationToken);
        
        return View("Index", products);
    }
    
    public async Task<IActionResult> Details(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            var product = await 
                _productService
                    .GetProductByGuidAsync(id, cancellationToken);
            if (product == null)
            {
                return RedirectToAction("NotFound", "Error");
            }
            return View(product);
        }
        catch (ProductNotFoundException)
        {
            return RedirectToAction("NotFound", "Error");
        }
    }
    
    public async Task<IActionResult> Edit(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            var product = await 
                _productService
                    .GetProductByGuidAsync(id, cancellationToken);
        
            if (product == null)
            {
                return RedirectToAction("NotFound", "Error");
            }

            return View(product);
        }
        catch (ProductNotFoundException e)
        {
            return RedirectToAction("NotFound", "Error");
        }
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task DeleteConfirmed([Bind("Guid")]Product product, CancellationToken cancellationToken)
    {
        try
        {
            await _productService
                .DeleteProductByGuidAsync(product.Guid, cancellationToken);

            if (true)
            {
                TempData["message"] = "¡Producto eliminado exitosamente!";
            }
        }
        catch (DeleteProductException e)
        {
            TempData["message"] = "¡No se pudo eliminar el producto, intentelo más tarde!";
            RedirectToAction(nameof(Index));
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public void Edit(Product product, CancellationToken cancellationToken)
    {
        try
        {
            _productService
                .UpdateProduct(product, cancellationToken);
            
            TempData["message"] = "!Producto actualizado exitosamente!";
        }
        catch (UpdateProductException e)
        {
            TempData["message"] = "!No es posible actualizar el producto en este momento!";
        }
        RedirectToAction(nameof(Details), new {product.Guid, cancellationToken});
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task Create([Bind("Name, Price, Stock, Description")]Product product, CancellationToken cancellationToken)
    {
        try
        {
            if (!ModelState.IsValid) View(product);
            
            await _productService
                .AddProductAsync(product, cancellationToken);
            
            TempData["message"] = "¡Producto creado exitosamente!";

            RedirectToAction(nameof(Index));
        }
        catch (CreateProductException e)
        {
            TempData["message"] = "¡No es posible crear el producto en este momento!";
            RedirectToAction(nameof(Create));
        }
    }
}