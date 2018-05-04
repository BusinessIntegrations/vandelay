#region Using
using System.Collections.Generic;
using Orchard.Environment.Extensions.Models;
using Orchard.Security.Permissions;
#endregion

namespace Vandelay.Industries {
    public class Permissions : IPermissionProvider {
        public static readonly Permission ManageVandelayFaviconSettings = new Permission {
            Description = "Managing Vandelay Favicon Settings",
            Name = nameof(ManageVandelayFaviconSettings)
        };

        private static readonly Permission[] permissions = {ManageVandelayFaviconSettings};

        #region IPermissionProvider Members
        public IEnumerable<PermissionStereotype> GetDefaultStereotypes() {
            return new[] {
                new PermissionStereotype {
                    Name = "Administrator",
                    Permissions = permissions
                }
            };
        }

        public IEnumerable<Permission> GetPermissions() {
            return permissions;
        }

        public virtual Feature Feature { get; set; }
        #endregion
    }
}
