#region Using
using System.Collections.Generic;
using Orchard;
using Vandelay.Industries.Models;
#endregion

namespace Vandelay.Industries.Services {
    public interface IFaviconService : IDependency {
        #region Methods
        /// <summary>
        ///     Provides a list of all files in the Favicon media folder.
        /// </summary>
        IList<FaviconUrlDetail> GetFaviconSuggestions();

        /// <summary>
        ///     Generates public Url given filename of a favicon
        /// </summary>
        SingleFavicon ResolveFavicon(SingleFavicon favicon);

        void ResolveFavicons(IList<SingleFavicon> singleFavicons);
        #endregion
    }
}
