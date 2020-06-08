using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stock.Web.Models.Account
{
    public class UserViewModel
    {
        public UserDetailViewModel UserDetailViewModel { get; set; }
        public ChangePassViewModel ChangePassViewModel { get; set; }
    }
}
