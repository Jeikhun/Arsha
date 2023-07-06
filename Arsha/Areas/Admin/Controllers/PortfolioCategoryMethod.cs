using Arsha.Context;
using Arsha.Models;
using Microsoft.AspNetCore.Mvc;

namespace Arsha.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PortfolioCategoryMethod : Controller
    {
        private readonly ArshaDbContext _arshaDbContext;

        public PortfolioCategoryMethod(ArshaDbContext arshaDbContext)
        {
            _arshaDbContext = arshaDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            PortfolioCategory portfolio = await _arshaDbContext.portfolioCategories.FindAsync(id);

            return View(portfolio);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(PortfolioCategory portfolioCategory, int id)
        {
            var exPortfolioCategory = await _arshaDbContext.portfolioCategories.FindAsync(id);
            exPortfolioCategory.Type= portfolioCategory.Type;
            exPortfolioCategory.UpdateTime= DateTime.Now;
            await _arshaDbContext.SaveChangesAsync();

            return RedirectToAction("createportfoliocategory", "create");
        }
    }
}
