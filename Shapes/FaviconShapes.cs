#region Using
using System.Linq;
using Orchard;
using Orchard.DisplayManagement.Descriptors;
using Orchard.UI.Resources;
using Vandelay.Industries.Services;
#endregion

namespace Vandelay.Industries.Shapes {
    public class FaviconShapes : IShapeTableProvider {
        private readonly IFaviconService _faviconService;
        private readonly IWorkContextAccessor _wca;

        public FaviconShapes(IWorkContextAccessor wca, IFaviconService faviconService) {
            _wca = wca;
            _faviconService = faviconService;
        }

        #region IShapeTableProvider Members
        public void Discover(ShapeTableBuilder builder) {
            builder.Describe("HeadLinks")
                .OnDisplaying(shapeDisplayingContext => {
                    var faviconList = _faviconService.GetFaviconList();
                    // Get the current favicon from head
                    var resourceManager = _wca.GetContext()
                        .Resolve<IResourceManager>();
                    var currentLinks = resourceManager.GetRegisteredLinks()
                        .ToList();
                    foreach (var favicon in faviconList) {
                        if (favicon != null &&
                            favicon.IsValid()) {
                            var favicon1 = favicon;
                            var findIndex = currentLinks.FindIndex(l => l.Rel == favicon1.Relation && l.Type == favicon1.LinkType);
                            var href = _faviconService.ResolveFavicon(favicon.Url);
                            // Modify if found
                            if (findIndex >= 0) {
                                currentLinks[findIndex]
                                    .Href = href;
                                //now remove this link from our temporary list as we don't want to inadvertently overwrite it again.
                                currentLinks.RemoveAt(findIndex);
                            }
                            else {
                                // Add the new one
                                resourceManager.RegisterLink(new LinkEntry {
                                    Type = favicon.LinkType,
                                    Rel = favicon.Relation,
                                    Href = href
                                });
                            }
                        }
                    }
                });
        }
        #endregion
    }
}
