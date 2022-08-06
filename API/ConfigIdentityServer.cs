using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public class ConfigIdentityServer
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>()
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile(),
                new IdentityResources.Phone(),
                new IdentityResource()
                {
                    Name = "Role",
                    UserClaims =new List<string> { "Role"}
                }
            };
        }


        public static IEnumerable<Client> GetClaims()
        {
            var claims = new List<Client>()
            {
                new Client()
                {
                    ClientId = "IdentityServer",
                    ClientName = "implement identity server",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    RedirectUris = new List<string> { "http://localhost:5052/login" },
                    PostLogoutRedirectUris = new List<string> { "http://localhost:5052/logout" },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Phone,
                    },
                }
                
            };
            return claims;
        }
    }
}
