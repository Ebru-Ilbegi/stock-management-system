using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace stock_management_system.Helpers
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly string[] allowedRoles;

        public CustomAuthorizeAttribute(params string[] roles)
        {
            this.allowedRoles = roles;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            // LoginController’da doldurduğun Session’dan rolü alıyoruz
            var role = httpContext.Session["Role"] as string;

            if (string.IsNullOrEmpty(role))
                return false;

            // Kullanıcının rolü allowedRoles içinde varsa erişim ver
            return allowedRoles.Any(r => r.Equals(role, StringComparison.OrdinalIgnoreCase));
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            // Yetkisiz ise Home/Unauthorized sayfasına yönlendir
            filterContext.Result = new RedirectResult("/Home/Index");
        }
    }
}
