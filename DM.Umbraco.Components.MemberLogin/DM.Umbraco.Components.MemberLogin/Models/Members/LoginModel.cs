using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Components.MemberLogin {
	public class LoginModel {

		[Required, Display(Name = "Enter your user name")]
		public string Login { get; set; }

		[Required, Display(Name = "Password"), DataType(DataType.Password)]
		public string Password { get; set; }

		[Display(Name = "Remember me")]
		public bool RememberMe { get; set; }
	}
}
