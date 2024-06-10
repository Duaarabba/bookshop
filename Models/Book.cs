using System.ComponentModel.DataAnnotations;

namespace bookshop.Models
{
    public class Book
    {
       
        public int Id { get; set; }
        [MaxLength(30)]
        public string Titel { get; set; } = null!;
        public string Publisher { get; set; } = null!;
        public DateTime PublishDate { get; set; }

        public string Description { get; set; } = null!;

        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime UpdateOn { get; set; } = DateTime.Now;
        public string? IMGurl { get; set; }
        public int AutherID { get; set; }
        public Auther Auther { get; set; } = null!;
        public List<BookCategory> Category{ get; set; } = new List<BookCategory>();
    }
}
