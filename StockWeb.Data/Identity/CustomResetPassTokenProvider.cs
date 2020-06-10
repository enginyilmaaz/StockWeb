using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace StockWeb.Data.Identity
{
    public class CustomResetPassTokenProvider<TUser> :
        DataProtectorTokenProvider<TUser> where TUser : class
    {

        public CustomResetPassTokenProvider(
            IDataProtectionProvider dataProtectionProvider,
            IOptions<CustomResetPassTokenProviderOptions> options,
            ILogger<DataProtectorTokenProvider<TUser>> logger) : base(dataProtectionProvider, options, logger)
        {

        }
    }
}
