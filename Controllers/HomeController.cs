using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _202303325web.Models;

namespace _202303325web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly DataContext _context;
    public HomeController(ILogger<HomeController> logger,DataContext ctx)
    {
        _logger = logger;
        _context=ctx;
        if(ctx.Anags.Count()==0){

            for(int i=0;i<10;i++){
                ctx.Anags.Add(new Anag{
                    FirstName=$"Nome{i}",
                    LastName=$"Cognome{i}"
                });
            }
            ctx.SaveChanges();
        }
    }

    public IActionResult Index()
    {
        return View(_context.Anags.ToList());
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
