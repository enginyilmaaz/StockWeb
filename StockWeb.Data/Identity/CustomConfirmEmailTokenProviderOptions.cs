using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace StockWeb.Data.Identity
{
    public class CustomConfirmEmailTokenProviderOptions : DataProtectionTokenProviderOptions
    {
        public CustomConfirmEmailTokenProviderOptions()
        {
            Name = "CustomConfirmEmailTokenProvider";
            TokenLifespan = TimeSpan.FromDays(7);
        } 
    
    }
}
