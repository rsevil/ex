using MediatR;
using System.Web.Mvc;

namespace EX.Presentation.WebSite.Controllers
{
    [Authorize]
    public abstract class ControllerBase : Controller
    {
        protected readonly IMediator _mediator;

        protected ControllerBase(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected void AddErrorNotification(string message)
        {
            TempData.Add("Notification-Error", message);
        }

        protected void AddSuccessNotification(string message)
        {
            TempData.Add("Notification-Success", message);
        }
    }
}