using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Net;

namespace ActiveDirectoryGroups.Services
{
    public class ActiveDirectoryGroupsService : IDisposable
    {
        private PrincipalContext principalContext;

        public IEnumerable<string> GetGroupNames(string username)
        {
            var webDecodedUsername = WebUtility.UrlDecode(username);
            principalContext = new PrincipalContext(ContextType.Machine);
            UserPrincipal user = UserPrincipal.FindByIdentity(principalContext, webDecodedUsername);

            if (user is null)
            {
                throw new ArgumentException(nameof(username));
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
