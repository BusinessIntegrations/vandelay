#region Using
using System.Collections.Generic;
using Vandelay.Industries.Models;
#endregion

namespace Vandelay.Industries.Services {
    public interface ICacheModel {
        #region Properties
        IList<SingleFavicon> SettingsPartFaviconUrl { get; }
        #endregion
    }
}
