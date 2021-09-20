using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Core.Requests.Bin;

namespace Warehouse.Core.Validators
{
    public class AddBinRequestValidator : AbstractValidator<AddBinRequest>
    {
        public AddBinRequestValidator()
        {
            RuleFor(x => x.Bin.Barcode).NotEmpty();
        }
    }
}
