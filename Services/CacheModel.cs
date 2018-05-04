#region Using
using System.Collections.Generic;
using Vandelay.Industries.Models;
#endregion

namespace Vandelay.Industries.Services {
    public class CacheModel : ICacheModel {
        public CacheModel(IList<SingleFavicon> settingsPartFaviconUrl) {
            SettingsPartFaviconUrl = settingsPartFaviconUrl;
        }

        #region ICacheModel Members
        public IList<SingleFavicon> SettingsPartFaviconUrl { get; }
        #endregion
    }
}
