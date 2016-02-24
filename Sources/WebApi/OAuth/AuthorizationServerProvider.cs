using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApi.Identity;

namespace WebApi.OAuth
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            return GrantResourceOwnerCredentialsAsync(context);
        }

        private async Task GrantResourceOwnerCredentialsAsync(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var manager = context.OwinContext.GetUserManager<ApplicationUserManager>();

            var user = await manager.FindAsync(context.UserName, context.Password);

            if (user == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }

            //TODO: verify that CreateIdentityAsync is the correct way to obtain a ClaimsIdentity object for the token
            var identityClaims = await manager.CreateIdentityAsync(user, context.Options.AuthenticationType);

            context.Validated(identityClaims);
        }
    }
}