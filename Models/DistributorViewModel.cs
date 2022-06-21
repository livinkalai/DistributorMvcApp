using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistributorMvcApp.Models
{
    public class DistributorViewModel
    {
        public IList<Distributor> Distributors { get; set; }
        public IList<OrderStages> OrderStages { get; set; }
    }
}