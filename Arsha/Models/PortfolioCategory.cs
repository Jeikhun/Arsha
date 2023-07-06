namespace Arsha.Models
{
    public class PortfolioCategory
    {
        public int Id { get; set; }
        public DateTime UpdateTime { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsDeleted { get; set; }
        public string Type { get; set; }
        public ICollection<Portfolio> portfolios { get; set; }
    }
}
