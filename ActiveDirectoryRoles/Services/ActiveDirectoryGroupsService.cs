using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Net;

namespace ActiveDirectoryRoles.Services
{
    public class ActiveDirectoryGroupsService : IDisposable
    {
        private PrincipalContext principalContext;

        public IEnumerable<string> GetGroups(string username)
        {
            var a = WebUtility.UrlDecode(username);
            principalContext = new PrincipalContext(ContextType.Domain);
            UserPrincipal user = UserPrincipal.FindByIdentity(principalContext, a);

            if (user is null)
            {
                throw new UserNotFoundException();
            }

            PrincipalSearchResult<Principal> groups = user.GetAuthorizationGroups();

            return groups.Select(g => g.Name);
        }

        public void Dispose()
        {
            principalContext?.Dispose();
        }
    }
}
