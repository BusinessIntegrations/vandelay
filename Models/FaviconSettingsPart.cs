#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using Orchard.ContentManagement;
using Orchard.Services;
#endregion

namespace Vandelay.Industries.Models {
    public class FaviconSettingsPart : ContentPart<FaviconSettingsPartRecord>, IFaviconSettingsPart {
        #region IFaviconSettingsPart Members
        public IList<SingleFavicon> FaviconUrlList { get => Deserialize(FaviconUrl); set => FaviconUrl = Serialize(value); }
        #endregion

        #region Properties
        public string FaviconUrl { get { return Retrieve(r => r.FaviconUrl); } set { Store(r => r.FaviconUrl, value); } }
        #endregion

        #region Methods
        private static IList<SingleFavicon> Deserialize(string favIcons) {
            IList<SingleFavicon> list;
            var converter = new DefaultJsonConverter();
            try {
                list = converter.Deserialize<IList<SingleFavicon>>(favIcons) ?? new List<SingleFavicon>();
            }
            catch (Exception) {
                list = new List<SingleFavicon>();
            }

            list.Add(new SingleFavicon());
            return list;
        }

        private static string Serialize(IEnumerable<SingleFavicon> favIcons) {
            var converter = new DefaultJsonConverter();
            return converter.Serialize(favIcons.Where(fi => !fi.IsEmpty()));
        }
        #endregion
    }
}
