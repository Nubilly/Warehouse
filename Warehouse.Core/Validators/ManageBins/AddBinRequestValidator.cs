using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Core.Requests.ManageBins;
using Warehouse.Core.Validators.ManageBins;
using Warehouse.Data.Stores;

namespace Warehouse.Core.Validators
{
    public class AddBinRequestValidator : AbstractValidator<AddBinRequest>
    {
        public AddBinRequestValidator(IBinStore binStore)
        {
            RuleFor(x => x.Bin).SetValidator(new BinValidator(binStore));
        }
    }
}
