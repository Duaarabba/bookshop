using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace bookshop.ViewModel
{
    public class BookVM
    {
        public int Id { get; set; }
      
        public string Titel { get; set; } = null!;

        public string Auther { get; set; } = null!;
        public string Publisher { get; set; } = null!;
      
        public DateTime PublishDate { get; set; } = DateTime.Now;
        
        public string? ImgURL { get; set; }


        public List<string> Category { get; set; } = null!; 
       
    }
}
