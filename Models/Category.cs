using System.ComponentModel.DataAnnotations;
using System.Data;

namespace bookshop.Models
{
    public class Category
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string Name { get; set; } 
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime UpdateOn { get; set; } = DateTime.Now;
    }
}
