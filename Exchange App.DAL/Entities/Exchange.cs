using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Exchange_App.DAL.Entities
{
    public class Exchange
    {
        public int Id { get; set; }

        [Required]
        public string Cashier { get; set; }

        public User Client { get; set; }

        public Currency ClientCurrency { get; set; }

        public Currency TargetCurrency { get; set; }

        [Required]
        [Range(1, 1000,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public double AmountClientCurrency { get; set; }

        public double AmountTargetCurrency { get; set; }
    }
}
