using Microsoft.AspNetCore.Identity;

namespace Warehouse.Identity
{
    public class WarehouseUser : IdentityUser
    {
        override public string UserName { get; set; } = "";
    }
}
