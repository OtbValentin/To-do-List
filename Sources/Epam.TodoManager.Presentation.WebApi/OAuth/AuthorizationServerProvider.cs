﻿using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Epam.TodoManager.Presentation.WebApi.Identity;

namespace Epam.TodoManager.Presentation.WebApi.OAuth
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

            var identityClaims = await manager.CreateIdentityAsync(user, context.Options.AuthenticationType);
            context.Validated(identityClaims);
        }
    }
}