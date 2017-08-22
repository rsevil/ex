using EX.Core.Commands;
using EX.Core.Queries;
using EX.Presentation.WebSite.Models.Home;
using MediatR;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Security;

namespace EX.Presentation.WebSite.Controllers
{
    [AllowAnonymous]
    public class HomeController : ControllerBase
    {
        public HomeController(IMediator mediator)
            : base(mediator) { }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(Index model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (!await _mediator.Send(new ExistsNotBlockedCreditCardQuery(model.CreditCardNumber)))
            {
                AddErrorNotification("The Credit Card is blocked or invalid");
                return View(model);
            }

            return View("Pin");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Pin(Pin model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (!await _mediator.Send(new ExistsNotBlockedCreditCardQuery(model.CreditCardNumber)))
            {
                AddErrorNotification("The Credit Card is blocked or invalid");
                return View("Index");
            }

            if (!await _mediator.Send(new MatchesCreditCardPinQuery(model.CreditCardNumber, model.PinNumber)))
            {
                await _mediator.Send(new IncreaseInvalidPinAttemptsCommand(model.CreditCardNumber));
                TempData.Add("Notification-Error", "The Credit Card and the Pin number do not match");
                return View(model);
            }

            // the credit cards exists && pin is valid
            var identity = new GenericIdentity(model.CreditCardNumber);
            var principal = new GenericPrincipal(identity, new[] { model.CreditCardNumber });
            HttpContext.User = principal;
            Thread.CurrentPrincipal = principal;
            FormsAuthentication.SetAuthCookie(model.CreditCardNumber, createPersistentCookie: true);

            return RedirectToAction("index", "operations");
        }

        public ActionResult Exit()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            return RedirectToAction("index", "home");
        }
    }
}