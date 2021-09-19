using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Common.Extensions
{
    public static class Extensions
    {
        public static string ReverseUsername(this string? username)
        {
            if (username == null)   
                return string.Empty;

            var usernameArray = username.ToCharArray();
            var reversedUsername = "";

            for (int i = usernameArray.Length -1; i >= 0; i--)
            {
                reversedUsername += usernameArray[i];
            }

            return reversedUsername;
        }
    }
}
