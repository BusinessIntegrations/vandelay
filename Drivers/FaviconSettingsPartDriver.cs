#region Using
using Orchard.Caching;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.Handlers;
using Vandelay.Industries.Models;
using Vandelay.Industries.Services;
using Vandelay.Industries.ViewModels;
#endregion

namespace Vandelay.Industries.Drivers {
    public class FaviconSettingsPartDriver : ContentPartDriver<FaviconSettingsPart> {
        private readonly IFaviconService _faviconService;
        private readonly ISignals _signals;

        public FaviconSettingsPartDriver(ISignals signals, IFaviconService faviconService) {
            _signals = signals;
            _faviconService = faviconService;
        }

        #region Properties
        protected override string Prefix => "FaviconSettings";
        #endregion

        #region Methods
        protected override DriverResult Editor(FaviconSettingsPart part, dynamic shapeHelper) {
            var faviconSuggestions = _faviconService.GetFaviconSuggestions();
            var singleFaviconsList = part.FaviconUrl;
            _faviconService.ResolveFavicons(singleFaviconsList);
            return ContentShape("Parts_Favicon_FaviconSettings",
                    () => shapeHelper.EditorTemplate(TemplateName: "Parts/Favicon.FaviconSettings",
                        Model: new FaviconSettingsViewModel {
                            FaviconUrl = singleFaviconsList,
                            FaviconUrlSuggestions = faviconSuggestions
                        },
                        Prefix: Prefix))
                .OnGroup(Constants.AdminMenuName);
        }

        protected override DriverResult Editor(FaviconSettingsPart part, IUpdateModel updater, dynamic shapeHelper) {
            updater.TryUpdateModel(part, Prefix, null, null);
            _signals.Trigger(Constants.CacheChanged);
            return Editor(part, shapeHelper);
        }

        protected override void Exporting(FaviconSettingsPart part, ExportContentContext context) {
            context.Element(part.PartDefinition.Name)
                .SetAttributeValue("FaviconUrl", part.Record.FaviconUrl);
        }

        protected override void Importing(FaviconSettingsPart part, ImportContentContext context) {
            var partDefinitionName = part.PartDefinition.Name;
            if (context.Data.Element(partDefinitionName) == null) {
                return;
            }
            part.Record.FaviconUrl = context.Attribute(part.PartDefinition.Name, "FaviconUrl");
        }
        #endregion
    }
}
