using Arsha.Models;

namespace Arsha.ViewModels
{
    public class ViewModel
    {
        public ICollection<Service> services { get; set; }
        public ICollection<Portfolio> portfolios { get; set; }
        public ICollection<PortfolioCategory> portfolioCategories { get; set; }


    }
}
