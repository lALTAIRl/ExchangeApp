using System;
using System.Collections.Generic;
using System.Text;

namespace Exchange_App.DAL.Entities
{
    public class Currency
    {
        public int Id { get; set; }

        public string CurrencyName { get; set; }

        public double PurchasePrice { get; set; }

        public double SellingPrice { get; set; }
    }
}
