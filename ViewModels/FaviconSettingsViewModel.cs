#region Using
using System.Collections.Generic;
using Vandelay.Industries.Models;
using Vandelay.Industries.Services;
#endregion

namespace Vandelay.Industries.ViewModels {
    public class FaviconSettingsViewModel : IFaviconSettingsPart {
        public FaviconSettingsViewModel() {
            RelSuggestions = new List<string> {
                "shortcut icon",
                "icon",
                "apple-touch-icon",
                "apple-touch-icon-precomposed"
            };
            TypeSuggestions = new List<string> {
                "image/x-icon",
                "image/png",
                "image/gif",
                "image/png"
            };
        }

        #region IFaviconSettingsPart Members
        public IList<SingleFavicon> FaviconUrlList { get; set; }
        #endregion

        #region Properties
        public IList<FaviconUrlDetail> FaviconUrlSuggestions { get; set; }
        public IList<string> RelSuggestions { get; }
        public IList<string> TypeSuggestions { get; }
        #endregion
    }
}
