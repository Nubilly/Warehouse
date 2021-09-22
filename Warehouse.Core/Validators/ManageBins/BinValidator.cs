using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Common.Models;
using Warehouse.Data.Stores;

namespace Warehouse.Core.Validators.ManageBins
{
	public class BinValidator : AbstractValidator<Bin>
	{
		public BinValidator(IBinStore binStore)
		{
			RuleFor(x => x.Barcode).NotEmpty().MustAsync(binStore.BinBarcodeAvaliable).WithMessage("Barcode already exists.");
			RuleFor(x => x.Label).NotEmpty();
			RuleFor(x => x.Location).NotEmpty();
		}
	}
}
