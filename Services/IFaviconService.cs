#region Using
using System.Collections.Generic;
using Orchard;
using Vandelay.Industries.Models;
#endregion

namespace Vandelay.Industries.Services {
    public interface IFaviconService : IDependency {
        #region Methods
        /// <summary>
        ///     Retrieves cached Favicon List
        /// </summary>
        /// <returns></returns>
        IList<SingleFavicon> GetFaviconList();

        /// <summary>
        ///     Provides a list of all files in the Favicon media folder.
        /// </summary>
        /// <returns></returns>
        IList<FaviconUrlDetail> GetFaviconSuggestions();

        /// <summary>
        ///     Generates public Url given filename of a favicon
        /// </summary>
        /// <param name="faviconUrl"></param>
        /// <returns></returns>
        string ResolveFavicon(string faviconUrl);

        void ResolveFavicons(IList<SingleFavicon> singleFavicons);
        #endregion
    }
}
