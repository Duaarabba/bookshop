using System.ComponentModel.DataAnnotations;

namespace bookshop.ViewModel
{
	public class AutherFormVM
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "PLZ Enter Your Name")]
		[MaxLength(10, ErrorMessage = "Your Name Must be at Least 10 Char")]
		public string AutherName { get; set; }

	}
}
