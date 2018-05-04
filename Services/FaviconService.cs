#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using Orchard.MediaLibrary.Services;
using Vandelay.Industries.Models;
#endregion

namespace Vandelay.Industries.Services {
    public class FaviconService : IFaviconService {
        private readonly IMediaLibraryService _mediaService;
        private bool? _exists;

        public FaviconService(IMediaLibraryService mediaService) {
            _mediaService = mediaService;
        }

        #region IFaviconService Members
        public IList<FaviconUrlDetail> GetFaviconSuggestions() {
            List<FaviconUrlDetail> faviconSuggestions = null;
            if (FaviconMediaFolderExists()) {
                faviconSuggestions = new List<FaviconUrlDetail>(_mediaService.GetMediaFiles(Constants.FaviconMediaFolder)
                    .Select(f => new FaviconUrlDetail(_mediaService.GetMediaPublicUrl(Constants.FaviconMediaFolder, f.Name), f.Name)));
            }

            return faviconSuggestions;
        }

        public SingleFavicon ResolveFavicon(SingleFavicon faviconUrl) {
            faviconUrl.SetPublicUrl(FaviconMediaFolderExists() && !string.IsNullOrEmpty(faviconUrl.Url)
                ? _mediaService.GetMediaPublicUrl(Constants.FaviconMediaFolder, faviconUrl.Url)
                : string.Empty);
            return faviconUrl;
        }

        /// <summary>
        ///     Generate Public URLs for each favicon so that the editor can display the images to be selected.
        /// </summary>
        /// <param name="singleFavicons"></param>
        public void ResolveFavicons(IList<SingleFavicon> singleFavicons) {
            foreach (var favicon in singleFavicons) {
                ResolveFavicon(favicon);
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
