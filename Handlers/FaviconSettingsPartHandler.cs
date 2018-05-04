#region Using
using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Vandelay.Industries.Models;
#endregion

namespace Vandelay.Industries.Handlers {
    public class FaviconSettingsPartHandler : ContentHandler {
        public FaviconSettingsPartHandler(IRepository<FaviconSettingsPartRecord> repository) {
            Filters.Add(StorageFilter.For(repository));
            Filters.Add(new ActivatingFilter<FaviconSettingsPart>(Constants.SiteContentTypeName));
        }
    }
}
