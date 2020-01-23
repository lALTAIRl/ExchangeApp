using System;
using System.Collections.Generic;
using System.Text;

namespace Exchange_App.DAL.Entities
{
    public class Exchange
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public User Cashier { get; set; }

        public User Client { get; set; }

        public Currency ClientCurrency { get; set; }

        public Currency TargetCurrency { get; set; }

        public double AmountClientCurrency { get; set; }

        public double AmountTargetCurrency { get; set; }
    }
}
