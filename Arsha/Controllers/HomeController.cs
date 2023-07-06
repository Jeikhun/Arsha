using Arsha.Context;
using Arsha.Models;
using Arsha.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Arsha.Controllers
{
    public class HomeController : Controller
    {
        private readonly ArshaDbContext _arshaDbContext;

        public HomeController(ArshaDbContext arshaDbContext)
        {
            _arshaDbContext = arshaDbContext;
        }
        public async Task<IActionResult> Index()
        {
            var model = new ViewModel();
            model.services = _arshaDbContext.Services
                .Where(id => !id.IsDeleted)
                .ToList();
            model.portfolioCategories = _arshaDbContext.portfolioCategories
                .Where(id => !id.IsDeleted)
                .ToList();
            model.portfolios = _arshaDbContext.Portfolios
                .Where(id => !id.IsDeleted)
                .ToList();

            return View(model);
        }
    }
}