using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;

namespace DM.Components.MemberLogin.Controllers.Members {
	public class MembershipController : Umbraco.Web.Mvc.SurfaceController {
		[HttpGet]
		[ActionName("MemberLogin")]
		public ActionResult Index() {
			return PartialView("Membership/MemberLogin", new LoginModel());
		}

		[HttpGet]
		public ActionResult Logout() {
			Session.Clear();
			FormsAuthentication.SignOut();
			return Redirect("/");
		}

		[HttpPost]
		[ActionName("MemberLogin")]
		public ActionResult Validate(LoginModel model) {
			if (Membership.ValidateUser(model.Login, model.Password)) {
				FormsAuthentication.SetAuthCookie(model.Login, model.RememberMe);
				Response.Redirect(Request.RawUrl);
			}

			TempData["Status"] = "Invalid Log-in Credentials";
			return RedirectToCurrentUmbracoPage();
		}
	}
}
