using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace StockWeb.Data.Entity
{
    public class Users: IdentityUser
    {

        public List<Sellings> Sellings { get; set; }
        public List<Purchases> Purchases { get; set; }

    }
}
