using System.ComponentModel.DataAnnotations;

namespace TestWebApplication.Models
{
    public class LoginViewModel
	{
		[Required]
		[Display(Name = "Логин")]
		public string UserName { get; set; }

		[Required]
		[UIHint("password")]
		[Display(Name = "Password")]
		public string Password { get; set; }

		[Display(Name = "Запомнить")]
		public bool RememberMe { get; set; }
	}
}
