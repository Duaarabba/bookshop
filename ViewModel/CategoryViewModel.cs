using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace bookshop.ViewModel
{
	public class CategoryViewModel
	{
		public int Id{ get; set; }
		[Required(ErrorMessage ="PLZ Enter Your Name")]
		[MaxLength(10, ErrorMessage ="Your Name Must be at Least 10 Char")]
		[Remote("CheckName" ,null,ErrorMessage ="The Name Exsist")]
		public string Name { get; set; } = null!;
		public DateTime CreatedOn { get; set; } = DateTime.Now;
		public DateTime UpdateOn { get; set; } = DateTime.Now;
	}
}
