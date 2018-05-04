#region Using
using Orchard;
using Vandelay.Industries.Models;
#endregion

namespace Vandelay.Industries.Services {
    public interface ICacheService : IDependency {
        #region Methods
        ICacheModel GetData();
        IFaviconSettingsPart GetSettings();
        void ReleaseCache();
        void UpdateSettings(IFaviconSettingsPart settings);
        #endregion
    }
}
