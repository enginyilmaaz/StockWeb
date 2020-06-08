using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockWeb.Data.Entity
{
    public class Purchases
    {
        public int Id { get; set; }

        public double PiecePrice { get; set; }

        public int Quantity { get; set; }
        public double TotalPrice { get; set; }

        public DateTime OperationTime { get; set; }

        public string UserId { get; set; }
        public Users User { get; set; }


        public int ProductId { get; set; }
        public Products Product { get; set; }

        public bool isActive { get; set; }

    }
}
