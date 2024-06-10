using bookshop.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace bookshop.ViewModel
{
    public class CreateBookVM
    {
        public int Id { get; set; }
        [MaxLength(30)]
        public string Titel { get; set; } = null!;
        [Display(Name ="Auther")]      
        public int AutherID { get; set; }
        public List<SelectListItem>? Auther { get; set; }
       
        public string Publisher { get; set; } = null!;
        [Display(Name = "Publish Date")]
        public DateTime PublishDate { get; set; } = DateTime.Now;
        [Display(Name ="Plz Choose  Img")]
        public IFormFile? ImgURL { get; set; }
        public string Description { get; set; } = null!;
        [Display(Name = "Plz Choose Category")]
        public List<int> SelectedCategory { get; set; } = new List<int>();
        public List<SelectListItem>? Category { get; set; }

    }
}
