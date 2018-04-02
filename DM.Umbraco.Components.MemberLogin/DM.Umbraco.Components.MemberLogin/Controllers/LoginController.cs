using DM.MemberLogin.Models;
using System.Web.Mvc;
using System.Web.Security;

namespace DM.MemberLogin.Controllers {
	public class LoginController : Umbraco.Web.Mvc.SurfaceController {
		[HttpGet]
		[ActionName("MemberLogin")]
		public ActionResult Index() {
			return PartialView("MemberLogin/MemberLogin", new LoginModel());
		}

		[HttpGet]
		public ActionResult Logout() {
			Session.Clear();
			FormsAuthentication.SignOut();
			return Redirect("/home");
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
