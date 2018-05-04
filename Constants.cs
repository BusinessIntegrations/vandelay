#region Using
using Vandelay.Industries.Controllers;
using Vandelay.Industries.Models;
#endregion

namespace Vandelay.Industries {
    public static class Constants {
        public const string AdminControllerName = "Admin";
        public const string AdminMenuName = "Favicon";
        public const string AreaName = "Vandelay.Industries";
        public const string BiMenuSection = "bi-menu-section";
        public const string CacheKey = "Vandelay.Favicon.Url";
        public const string CacheTrigger = "Vandelay.Favicon.Changed";
        public const string CannotManageText = "Can't manage Vandelay Favicon Settings";
        public const string ColumnName = nameof(FaviconSettingsPartRecord.FaviconUrl);
        public const string FaviconMediaFolder = "favicon";
        public const string FaviconSettingsPartRecordName = nameof(FaviconSettingsPartRecord);
        public const string IndexActionName = nameof(AdminController.Index);
        public const string SiteContentTypeName = "Site";
        public const string ValidationErrorText = "Validation error";
    }
}
