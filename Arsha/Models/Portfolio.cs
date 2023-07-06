using System.ComponentModel.DataAnnotations.Schema;

namespace Arsha.Models
{
    public class Portfolio
    {
        public int Id { get; set; }
        public DateTime UpdateTime { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsDeleted { get; set; }

        public string? Image { get; set; }
        public int PortfolioCategoryId { get; set; }
        public PortfolioCategory? PortfolioCategory { get; set; }
        [NotMapped]
        public IFormFile FormFile { get; set; }
    }
}
