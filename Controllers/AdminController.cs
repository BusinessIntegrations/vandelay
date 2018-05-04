#region Using
using System.Web.Mvc;
using Orchard;
using Orchard.Localization;
using Orchard.Themes;
using Orchard.UI.Admin;
using Orchard.UI.Notify;
using Vandelay.Industries.Models;
using Vandelay.Industries.Services;
using Vandelay.Industries.ViewModels;
#endregion

namespace Vandelay.Industries.Controllers {
    [Themed]
    [Admin]
    public class AdminController : Controller {
        private readonly ICacheService _cacheService;
        private readonly IFaviconService _faviconService;
        private readonly IOrchardServices _orchardServices;

        public AdminController(IOrchardServices orchardServices, ICacheService cacheService, IFaviconService faviconService) {
            _orchardServices = orchardServices;
            _cacheService = cacheService;
            _faviconService = faviconService;
            T = NullLocalizer.Instance;
        }

        #region Properties
        public Localizer T { get; set; }
        #endregion

        #region Methods
        public ActionResult Index() {
            if (!_orchardServices.Authorizer.Authorize(Permissions.ManageVandelayFaviconSettings, T(Constants.CannotManageText))) {
                return new HttpUnauthorizedResult();
            }

            var prettifySettingsViewModel = GetViewModel();
            return View(prettifySettingsViewModel);
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult IndexPost(FaviconSettingsViewModel model) {
            if (!_orchardServices.Authorizer.Authorize(Permissions.ManageVandelayFaviconSettings, T(Constants.CannotManageText))) {
                return new HttpUnauthorizedResult();
            }

            if (ModelState.IsValid) {
                if (TryUpdateModel(model)) {
                    UpdatePart(model);
                    _orchardServices.Notifier.Information(T("Vandelay Favicon settings saved successfully."));
                    _orchardServices.Notifier.Information(T("Remember if you are using the Output Cache that you need to clear it."));
                }
                else {
                    _orchardServices.Notifier.Information(T("Could not save Vandelay Favicon settings."));
                }
            }
            else {
                _orchardServices.Notifier.Error(T(Constants.ValidationErrorText));
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        private FaviconSettingsViewModel GetViewModel() {
            var faviconUrlList = _cacheService.GetSettings().FaviconUrlList;
            _faviconService.ResolveFavicons(faviconUrlList);
            return new FaviconSettingsViewModel {
                FaviconUrlList = faviconUrlList,
                FaviconUrlSuggestions = _faviconService.GetFaviconSuggestions()
            };
        }

        private void UpdatePart(IFaviconSettingsPart model) {
            _cacheService.UpdateSettings(model);
        }
        #endregion
    }
}
