#region Using
using System.Collections.Generic;
#endregion

namespace Vandelay.Industries.Models {
    public interface IFaviconSettingsPart {
        #region Properties
        IList<SingleFavicon> FaviconUrlList { get; }
        #endregion
    }
}
