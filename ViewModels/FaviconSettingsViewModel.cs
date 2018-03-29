#region Using
using System.Collections.Generic;
using Vandelay.Industries.Models;
using Vandelay.Industries.Services;
#endregion

namespace Vandelay.Industries.ViewModels {
    public class FaviconSettingsViewModel {
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

        #region Properties
        public IList<SingleFavicon> FaviconUrl { get; set; }
        public IList<FaviconUrlDetail> FaviconUrlSuggestions { get; set; }
        public IList<string> RelSuggestions { get; }
        public IList<string> TypeSuggestions { get; }
        #endregion
    }
}
