using MediatR;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Common;
using Warehouse.Core.Requests.ManageBins;

namespace Warehouse.Controllers
{
    public class BinController : Controller
    {
        private readonly IMediator mediator;

        public BinController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var response = await mediator.Send(new ListBinRequest { }, HttpContext.RequestAborted);

            return View(response.Bins);
        }

        [HttpPost]
        public async Task<IActionResult> Index(Pager pager)
        {
            ViewData["Pager"] = pager;

            var response = await mediator.Send(new ListBinRequest { Pager = pager }, HttpContext.RequestAborted);

            return View(response.Bins);
        }

        public async Task<IActionResult> Get([FromRoute] string barcode)
        {
            var response = await mediator.Send(new GetBinRequest { Barcode = barcode }, HttpContext.RequestAborted);

            if (response.ResponseCode == Core.Requests.ResponseCode.ValidationFailed)
            {
                foreach (var error in response.Errors)
                {
                    ModelState.AddModelError("", error.Value);
                }
            }

            if (ModelState.IsValid)
                return RedirectToAction("Index");

            return View(response.Bin);
        }

        public IActionResult Add()
        {
            return View(new Common.Models.Bin());
        }

        [HttpPost]
        public async Task<IActionResult> Add(Common.Models.Bin bin)
        {
            var response = await mediator.Send(new AddBinRequest { Bin = bin }, HttpContext.RequestAborted);

            if (response.ResponseCode == Core.Requests.ResponseCode.ValidationFailed)
            {
                foreach (var error in response.Errors)
                {
                    ModelState.AddModelError("", error.Value);
                }
            }

            if (ModelState.IsValid)
                return RedirectToAction("Index");

            return View(bin);
        }

        public async Task<IActionResult> Update(string barcode)
        {
            var response = await mediator.Send(new GetBinRequest { Barcode = barcode }, HttpContext.RequestAborted);

            if (response.ResponseCode == Core.Requests.ResponseCode.ValidationFailed)
            {
                foreach (var error in response.Errors)
                {
                    ModelState.AddModelError("", error.Value);
                }
            }

            return View(response.Bin);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Common.Models.Bin bin)
        {
            var response = await mediator.Send(new UpdateBinRequest { Bin = bin }, HttpContext.RequestAborted);

            if (response.ResponseCode == Core.Requests.ResponseCode.ValidationFailed)
            {
                foreach (var error in response.Errors)
                {
                    ModelState.AddModelError("", error.Value);
                }
            }

            if (ModelState.IsValid)
                return RedirectToAction("Index");

            return View(bin);
        }

        public async Task<IActionResult> Remove(string barcode)
        {
            var response = await mediator.Send(new GetBinRequest { Barcode = barcode }, HttpContext.RequestAborted);

            if (response.ResponseCode == Core.Requests.ResponseCode.ValidationFailed)
            {
                foreach (var error in response.Errors)
                {
                    ModelState.AddModelError("", error.Value);
                }
            }

            return View(response.Bin);
        }


        [HttpPost]
        public async Task<IActionResult> RemoveConfirmed(string barcode)
        {
            var response = await mediator.Send(new RemoveBinRequest { Barcode = barcode }, HttpContext.RequestAborted);

            if (response.ResponseCode == Core.Requests.ResponseCode.ValidationFailed)
            {
                foreach (var error in response.Errors)
                {
                    ModelState.AddModelError("", error.Value);
                }
            }

            if (ModelState.IsValid)
                return RedirectToAction("Index");

            return RedirectToAction("Remove", new { barcode = barcode });
        }
    }
}
