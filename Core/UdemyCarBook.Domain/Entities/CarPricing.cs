﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Domain.Entities
{
    public class CarPricing
    {
        public int CarPricingId { get; set; }
        public int CarId { get; set; }
        public int PricingId{ get; set; }
        public decimal Amount { get; set; }

        public Car Car { get; set; }
        public Pricing Pricing{ get; set; }
    }
}
