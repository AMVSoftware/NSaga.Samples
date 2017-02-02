using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace MVCSample.Infrastructure
{
    public class AspNetPrincipalProxy : IPrincipal
    {
        public IIdentity Identity => User.Identity;
        public bool IsInRole(string role) => User.IsInRole(role);
        private IPrincipal User => HttpContext.Current.User;
    }
}