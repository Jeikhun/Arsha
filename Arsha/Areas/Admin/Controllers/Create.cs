using Arsha.Context;
using Arsha.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace Arsha.Areas.Admin.Controllers
{
        [Area("Admin")]
    public class Create : Controller
    {

        private readonly ArshaDbContext _arshaDbContext;
        public Create(ArshaDbContext arshaDbContext)
        {
            _arshaDbContext = arshaDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> CreateService()
        {
            var services =  _arshaDbContext.Services
                .Where(id => !id.IsDeleted)
                .ToList();
            return View(services);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> CreateService(Service service)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            service.CreatedTime = DateTime.Now;
            await _arshaDbContext.Services.AddAsync(service);
            await _arshaDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(CreateService));
        }
        public IActionResult DeleteService(int id)
        {
            var service = _arshaDbContext.Services
                .Where(x => !x.IsDeleted && x.Id == id)
                .ToList().FirstOrDefault();
            if (service == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            service.IsDeleted = true;
            _arshaDbContext.SaveChanges();
            return RedirectToAction("createservice", "create");
        }

        
        public IActionResult UpdateService(int id)
        {
            var service = _arshaDbContext.Services.Find(id);
            if (service == null) { return NotFound(); }

            return View(service);
        }
        [HttpPost]

        [ValidateAntiForgeryToken]
        public IActionResult UpdateService(Service service,int id)
        {
            
            if (!ModelState.IsValid) { return View(); }
            var model = _arshaDbContext.Services.Find(id);
            if(model == null) { return NotFound(); }
            model.Title = service.Title;
            model.Image = service.Image;
            model.Text = service.Text;
            _arshaDbContext.SaveChanges();


            return RedirectToAction("createservice", "create");
        }
        public async Task<IActionResult> CreatePortfolioCategory()
        {
            var portfolioCategories = _arshaDbContext.portfolioCategories
                .Where(id => !id.IsDeleted)
                .ToList();
            return View(portfolioCategories);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePortfolioCategory(PortfolioCategory portfolioCategory)
        {
            portfolioCategory.CreatedTime= DateTime.Now;
            await _arshaDbContext.portfolioCategories.AddAsync(portfolioCategory);
            await _arshaDbContext.SaveChangesAsync();
            return RedirectToAction("createportfoliocategory", "create");
        }

       

        public IActionResult DeletePortfolioCategory(int id)
        {
            var portfolioCategory = _arshaDbContext.portfolioCategories
                .Where(x => !x.IsDeleted && x.Id == id)
                .ToList().FirstOrDefault();
            if (portfolioCategory == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            portfolioCategory.IsDeleted = true;
            _arshaDbContext.SaveChanges();
            return RedirectToAction("createportfoliocategory", "create");
        }
        //public async Task<IActionResult> CreatePortfolio()
        //{
        //    var portfolios = _arshaDbContext.Portfolios
        //        .Where(id => !id.IsDeleted)
        //        .ToList();
        //    return View(portfolios);
        //}

        //[HttpPost]
        //public async Task<IActionResult> CreatePortfolio(Portfolio portfolio)
        //{
        //    await _arshaDbContext.portfolioCategories.AddAsync(portfolio);
        //    await _arshaDbContext.SaveChangesAsync();
        //    return RedirectToAction("createportfolio", "create");
        //}

    }
}
