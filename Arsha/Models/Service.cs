using System.ComponentModel.DataAnnotations;

namespace Arsha.Models
{
    public class Service
    {
        public int Id { get; set; }
        public DateTime UpdateTime { get; set; }
        public DateTime CreatedTime { get; set; } 
        public bool IsDeleted { get; set; }
        [Required(ErrorMessage = "Bosh ola bilmez")] //bos girdikdde error message
        public string Title { get; set; }
        public string Image { get; set; }
        public string Text { get; set; }

    }
}
