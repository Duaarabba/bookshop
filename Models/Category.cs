using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace bookshop.Models
{
    [Index(nameof(Name),IsUnique =true)]
   
   
    public class Category
    {
        public int Id { get; set; }

        [MaxLength(20)]
		
		public string Name { get; set; } = null!;
		public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime UpdateOn { get; set; } = DateTime.Now;

        public List<BookCategory> Book { get; set; } = new List<BookCategory>();
    }
}
