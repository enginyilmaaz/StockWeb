using Microsoft.AspNetCore.Identity;
using System;

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
