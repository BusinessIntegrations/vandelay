namespace Vandelay.Industries.Services {
    /// <summary>
    ///     Class is used to manage lists of favicon suggestions.
    /// </summary>
    public class FaviconUrlDetail {
        public FaviconUrlDetail(string publicUrl, string fileName) {
            PublicUrl = publicUrl;
            FileName = fileName;
        }

        #region Properties
        public string FileName { get; }
        public string PublicUrl { get; }
        #endregion
    }
}
