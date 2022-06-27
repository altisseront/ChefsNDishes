using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChefsNDishes.Models;

namespace ChefsNDishes.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.AllChefs = _context.Chefs.Include(a => a.DishesMade).ToList();
        return View();
    }
    [HttpGet("dishes")]
    public IActionResult Dishes()
    {
        ViewBag.AllDishes = _context.Dishes.Include(a => a.Chef).ToList();
        return View();
    }
    [HttpGet("chef/add")]
    public IActionResult AddChef()
    {
        return View();
    }
    [HttpGet("dish/add")]
    public IActionResult AddDish()
    {
        ViewBag.AllChefs = _context.Chefs.OrderBy(a => a.ChefId).ToList();
        return View();
    }
    [HttpPost("addchef")]
    public IActionResult AddChef(Chef newChef)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newChef);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return View("AddChef");
        }
    }
    [HttpPost("adddish")]
    public IActionResult AddDish(Dish newDish)
    {
        ViewBag.AllChefs = _context.Chefs.OrderBy(a => a.ChefId).ToList();
        if(ModelState.IsValid)
        {
            _context.Add(newDish);
            _context.SaveChanges();
            Console.WriteLine("Sucess");
            return RedirectToAction("Dishes");
        }
        else
        {
            return View("AddDish");
        }
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
