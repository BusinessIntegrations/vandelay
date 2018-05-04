#region Using
using Orchard;
using Orchard.Caching;
using Orchard.ContentManagement;
using Vandelay.Industries.Models;
#endregion

namespace Vandelay.Industries.Services {
    public class CacheService : ICacheService {
        private readonly ICacheManager _cacheManager;
        private readonly IOrchardServices _orchardServices;
        private readonly ISignals _signals;

        public CacheService(ICacheManager cacheManager, IOrchardServices orchardServices, ISignals signals) {
            _cacheManager = cacheManager;
            _orchardServices = orchardServices;
            _signals = signals;
        }

        #region ICacheService Members
        public ICacheModel GetData() {
            return _cacheManager.Get(Constants.CacheKey,
                context => {
                    context.Monitor(_signals.When(Constants.CacheTrigger));
                    var settingsPart = GetSettingsPart();
                    return new CacheModel(settingsPart.FaviconUrlList);
                });
        }

        public IFaviconSettingsPart GetSettings() {
            return GetSettingsPart();
        }

        public void ReleaseCache() {
            _signals.Trigger(Constants.CacheTrigger);
        }

        public void UpdateSettings(IFaviconSettingsPart settings) {
            var part = GetSettingsPart();
            part.FaviconUrlList = settings.FaviconUrlList;
            ReleaseCache();
        }
        #endregion

        #region Methods
        private FaviconSettingsPart GetSettingsPart() {
            return _orchardServices.WorkContext.CurrentSite.As<FaviconSettingsPart>();
        }
        #endregion
    }
}
