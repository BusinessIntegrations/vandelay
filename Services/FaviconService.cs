#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using Orchard;
using Orchard.Caching;
using Orchard.MediaLibrary.Services;
using Vandelay.Industries.Models;
#endregion

namespace Vandelay.Industries.Services {
    public class FaviconService : IFaviconService {
        private readonly ICacheManager _cacheManager;
        private readonly IMediaLibraryService _mediaService;
        private readonly ISignals _signals;
        private readonly IWorkContextAccessor _wca;
        private bool? _exists;

        public FaviconService(IWorkContextAccessor wca, ICacheManager cacheManager, ISignals signals, IMediaLibraryService mediaService) {
            _wca = wca;
            _cacheManager = cacheManager;
            _signals = signals;
            _mediaService = mediaService;
        }

        #region IFaviconService Members
        public IList<SingleFavicon> GetFaviconList() {
            return _cacheManager.Get("Vandelay.Favicon.Url",
                ctx => {
                    ctx.Monitor(_signals.When(Constants.CacheChanged));
                    var workContext = _wca.GetContext();
                    var faviconSettings = (FaviconSettingsPart) workContext.CurrentSite.ContentItem.Get(typeof(FaviconSettingsPart));
                    return faviconSettings.FaviconUrl;
                });
        }

        public IList<FaviconUrlDetail> GetFaviconSuggestions() {
            List<FaviconUrlDetail> faviconSuggestions = null;
            if (FaviconMediaFolderExists()) {
                faviconSuggestions = new List<FaviconUrlDetail>(_mediaService.GetMediaFiles(Constants.FaviconMediaFolder)
                    .Select(f => new FaviconUrlDetail(_mediaService.GetMediaPublicUrl(Constants.FaviconMediaFolder, f.Name), f.Name)));
            }
            return faviconSuggestions;
        }

        public string ResolveFavicon(string faviconUrl) {
            return FaviconMediaFolderExists() && !string.IsNullOrEmpty(faviconUrl)
                ? _mediaService.GetMediaPublicUrl(Constants.FaviconMediaFolder, faviconUrl)
                : string.Empty;
        }

        /// <summary>
        ///     Generate Public URLs for each favicon so that the editor can display the images to be selected.
        /// </summary>
        /// <param name="singleFavicons"></param>
        public void ResolveFavicons(IList<SingleFavicon> singleFavicons) {
            foreach (var favicon in singleFavicons) {
                favicon.SetPublicUrl(ResolveFavicon(favicon.Url));
            }
        }
        #endregion

        #region Methods
        private bool FaviconMediaFolderExists() {
            if (!_exists.HasValue) {
                _exists = _mediaService.GetMediaFolders(null)
                              .FirstOrDefault(f => f.Name.Equals(Constants.FaviconMediaFolder, StringComparison.OrdinalIgnoreCase)) != null;
            }
            return _exists.Value;
        }
        #endregion
    }
}
