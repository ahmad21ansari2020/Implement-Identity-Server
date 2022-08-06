using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ConfigIdentityServer
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            var resources = new List<IdentityResource>()
            {
                new IdentityResources.Email(),
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Phone(),
                new IdentityResource()
                {
                     Name ="Role",
                     UserClaims =new  List<string>(){"Role"}
                }

            };
            return resources;
        }

    }
}
