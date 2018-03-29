namespace Vandelay.Industries.Models {
    public class SingleFavicon {
        private string _publicUrl;

        #region Properties
        public string LinkType { get; set; }
        public string Relation { get; set; }
        public string Url { get; set; }
        #endregion

        #region Methods
        public string GetPublicUrl() {
            return _publicUrl;
        }

        public bool IsEmpty() {
            return string.IsNullOrWhiteSpace(LinkType) && string.IsNullOrEmpty(Url) && string.IsNullOrEmpty(Relation);
        }

        public bool IsValid() {
            return !string.IsNullOrWhiteSpace(LinkType) && !string.IsNullOrEmpty(Url) && !string.IsNullOrEmpty(Relation);
        }

        public void SetPublicUrl(string resolveFavicon) {
            _publicUrl = resolveFavicon;
        }
        #endregion
    }
}
