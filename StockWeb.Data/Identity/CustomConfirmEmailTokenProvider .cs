using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace StockWeb.Data.Identity
{
    public class CustomConfirmEmailTokenProvider<TUser> :
        DataProtectorTokenProvider<TUser> where TUser : class
    {

        public CustomConfirmEmailTokenProvider(
            IDataProtectionProvider dataProtectionProvider,
            IOptions<CustomConfirmEmailTokenProviderOptions> options,
            ILogger<DataProtectorTokenProvider<TUser>> logger) : base(dataProtectionProvider, options, logger)
        {

        }
    }
}
