using Microsoft.AspNetCore.Identity;
using System;

namespace StockWeb.Data.Identity
{
    public class CustomResetPassTokenProviderOptions : DataProtectionTokenProviderOptions
    {
        public CustomResetPassTokenProviderOptions()
        {
            Name = "CustomResetPassTokenProvider";
            TokenLifespan = TimeSpan.FromHours(1);
        }

    }
}
