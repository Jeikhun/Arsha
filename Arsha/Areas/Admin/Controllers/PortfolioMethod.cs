using Arsha.Context;
using Arsha.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Cryptography.X509Certificates;

namespace Arsha.Areas.Admin.Controllers
{
    
    [Area("Admin")]
    public class PortfolioMethod : Controller
    {
        private readonly ArshaDbContext _arshaDbContext;
        private IWebHostEnvironment _env;

        public PortfolioMethod(ArshaDbContext arshaDbContext, IWebHostEnvironment env)
        {
            _arshaDbContext = arshaDbContext;
            _env = env;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var portfolios = _arshaDbContext.Portfolios.Where(x => !x.IsDeleted).ToList();
            return View(portfolios);
        }
        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Portfolio portfolio)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (!portfolio.FormFile.ContentType.Contains("image"))//yanlish extention ile file daxil edilmesinin qarshisinin alinmasi uchun
            {
                ModelState.AddModelError("FormFile", "Duzgun daxil etmemisiniz"); //error mesaji qaytarmaq uchun
            }
            string root = _env.WebRootPath;
            string path = "assets/img/";
            string fileName =Guid.NewGuid().ToString()+portfolio.FormFile.FileName;
            string FullPath = Path.Combine(root,path, fileName);

            using (FileStream fileStream = new FileStream(FullPath, FileMode.Create))
            {
                portfolio.FormFile.CopyTo(fileStream);
            }
            portfolio.Image = fileName;
                portfolio.CreatedTime = DateTime.Now;
            await _arshaDbContext.Portfolios.AddAsync(portfolio);
            await _arshaDbContext.SaveChangesAsync();
            return RedirectToAction("index", "portfoliomethod");
        }

        [HttpGet]
        public async Task<IActionResult>Delete(int id)
        {
            Portfolio portfolio = await _arshaDbContext.Portfolios.FindAsync(id);
            portfolio.IsDeleted=true;
            _arshaDbContext.SaveChanges();  

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult>Update(int id)
        {
            Portfolio portfolio = await _arshaDbContext.Portfolios.FindAsync(id);

            return View(portfolio);
        }
        [HttpPost]
        public async Task<IActionResult>Update(Portfolio portfolio,int id)
        {
            Portfolio exPortfolio = await _arshaDbContext.Portfolios.FindAsync(id);
            exPortfolio.PortfolioCategoryId = portfolio.PortfolioCategoryId;
            exPortfolio.Image = portfolio.Image;
            portfolio.CreatedTime= DateTime.Now;
            await _arshaDbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
