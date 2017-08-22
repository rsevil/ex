using EX.Core.Commands;
using EX.Core.Queries;
using EX.Presentation.WebSite.Models.Operations;
using MediatR;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EX.Presentation.WebSite.Controllers
{
    public class OperationsController : ControllerBase
    {
        public OperationsController(IMediator mediator)
            : base(mediator) { }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Balance()
        {
            await _mediator.Send(
                new LogBalanceCommand(HttpContext.User.Identity.Name, DateTimeOffset.UtcNow));

            var balance = await _mediator.Send(new BalanceQuery(HttpContext.User.Identity.Name));

            return View(balance);
        }

        public ActionResult Withdrawal()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Withdrawal(Withdrawal model)
        {
            var canWithdraw = await _mediator.Send(
                new CanWithdrawAmountQuery(HttpContext.User.Identity.Name, model.Amount));

            if (!canWithdraw)
            {
                AddErrorNotification($"Cannot withdraw ${model.Amount.ToString("#0.00")} from account");
                return View(model);
            }

            await _mediator.Send(
                new WithdrawCommand(HttpContext.User.Identity.Name, DateTimeOffset.UtcNow, model.Amount));

            AddSuccessNotification($"Successfully Withdrawed ${model.Amount.ToString("#0.00")} from account");

            return RedirectToAction("index", "operations");
        }
    }
}