using MediatR;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Common;
using Warehouse.Core.Requests.Bin;

namespace Warehouse.Controllers
{
    public class BinController : Controller
    {
        private readonly IMediator mediator;

        public BinController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index([FromQuery] Pager pager)
        {
            ViewData["Pager"] = pager;

            var response = await mediator.Send(new ListBinRequest { Pager = pager ?? new Pager() }, HttpContext.RequestAborted);

            return View(response.Bins);
        }
    }
}
