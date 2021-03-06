﻿using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using PhotoAlbum.BLL.Interfaces;

namespace PhotoAlbum.WebApi.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private IUserService _userService;

        public ApplicationOAuthProvider(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var user = await _userService.FindAsync(context.UserName, context.Password);

            if (user != null)
            {
                var oAuthIdentity = new ClaimsIdentity(context.Options.AuthenticationType);
                var roles = await _userService.GetRolesAsync(user.Id);
                oAuthIdentity.AddClaim(new Claim("Name", user.UserName));
                oAuthIdentity.AddClaim(new Claim("Email", user.Email));
                foreach(var role in roles)
                {
                    oAuthIdentity.AddClaim(new Claim(ClaimTypes.Role, role));
                }

                var additionalData = new AuthenticationProperties(new Dictionary<string, string>
                {
                    {
                        "role", Newtonsoft.Json.JsonConvert.SerializeObject(roles)
                    }
                });

                var ticket = new AuthenticationTicket(oAuthIdentity, additionalData);
                context.Validated(ticket);
            }

        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach(KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }
            return Task.FromResult<object>(null);
        }
    }
}