//Book Model
namespace CodVeda_FullStack_Intern.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
        public string PublishDate { get; set; } = string.Empty;
        public string Summary { get; set; } = string.Empty;
        public bool IsHidden { get; set; } = false; 
    }
}
