using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace StockWeb.Data.Identity
{
    public class CustomResetPassTokenProviderOptions:DataProtectionTokenProviderOptions
    {
        public CustomResetPassTokenProviderOptions()
        {
            Name = "CustomResetPassTokenProvider";
            TokenLifespan = TimeSpan.FromHours(1);
        } 
    
    }
}
