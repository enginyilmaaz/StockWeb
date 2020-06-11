using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace StockWeb.Data.Entity
{
    public class Users : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }



        public bool isActive { get; set; }


        public List<Sellings> Sellings { get; set; }
        public List<Purchases> Purchases { get; set; }

    }
}
