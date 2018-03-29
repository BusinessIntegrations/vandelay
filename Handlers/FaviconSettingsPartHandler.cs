#region Using
using Orchard.ContentManagement;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Orchard.Localization;
using Vandelay.Industries.Models;
#endregion

namespace Vandelay.Industries.Handlers {
    public class FaviconSettingsPartHandler : ContentHandler {
        public FaviconSettingsPartHandler(IRepository<FaviconSettingsPartRecord> repository) {
            T = NullLocalizer.Instance;
            Filters.Add(StorageFilter.For(repository));
            Filters.Add(new ActivatingFilter<FaviconSettingsPart>("Site"));
        }

        #region Properties
        public Localizer T { get; set; }
        #endregion

        #region Methods
        protected override void GetItemMetadata(GetContentItemMetadataContext context) {
            if (context.ContentItem.ContentType != "Site") {
                return;
            }
            base.GetItemMetadata(context);
            context.Metadata.EditorGroupInfo.Add(new GroupInfo(T(Constants.AdminMenuName)) {
                Position = "1"
            });
        }
        #endregion
    }
}
