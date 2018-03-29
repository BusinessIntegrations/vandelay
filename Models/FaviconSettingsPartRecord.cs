#region Using
using Orchard.ContentManagement.Records;
#endregion

namespace Vandelay.Industries.Models {
    public class FaviconSettingsPartRecord : ContentPartRecord {
        #region Properties
        public virtual string FaviconUrl { get; set; }
        #endregion
    }
}
