using DistributorMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistributorMvcApp.DAL
{
    public static class DALService
    {
        public static IList<Distributor> GetDistributors()
        {
            Distributor dist1 = new Distributor()
            {
                Name = "Distributor1",
                Id = 1,
                Orders = new List<Order>() {
                    new Order(1, Status.Open),
                    new Order(7, Status.InProgress),
                    new Order(8, Status.Completed)
                }
            };
            dist1.FillEmpties();
            Distributor dist2 = new Distributor()
            {
                Name = "Distributor2",
                Id = 2,
                Orders = new List<Order>() {
                    new Order(1, Status.InProgress),
                    new Order(7, Status.Completed),
                    new Order(3, Status.Open)
                }
            };
            dist2.FillEmpties();
            Distributor dist3 = new Distributor()
            {
                Name = "Distributor3",
                Id = 3,
                Orders = new List<Order>() {
                    new Order(1, Status.Completed),
                    new Order(2, Status.Open),
                    new Order(7, Status.InProgress)
                }
            };
            dist3.FillEmpties();

            Distributor dist4 = new Distributor()
            {
                Name = "Distributor4",
                Id = 4,
                Orders = new List<Order>() {
                    new Order(1, Status.Completed),
                    new Order(2, Status.Open),
                    new Order(7, Status.InProgress)
                }
            };
            dist4.FillEmpties();

            Distributor dist5 = new Distributor()
            {
                Name = "Distributor5",
                Id = 5,
                Orders = new List<Order>() { }
            };
            dist5.FillEmpties();

            Distributor dist6 = new Distributor()
            {
                Name = "Distributor6",
                Id = 6,
                Orders = new List<Order>() { }
            };
            dist6.FillEmpties();


            List<Distributor> distributors = new List<Distributor>() { dist1, dist2, dist3, dist4, dist5, dist6 };
            return distributors;
        }

        private static IList<OrderStages> _orderStages { get; set; }
        public static IList<OrderStages> GetOrderStages()
        {
            if (_orderStages == null)
            {
                _orderStages = new List<OrderStages>()            {
                new OrderStages(1, "New Order"),
                new OrderStages(2, "Send SQ"),
                new OrderStages(3, "Order Confirmed"),
                new OrderStages(4, "Send OC"),
                new OrderStages(5, "Send PI"),
                new OrderStages(6, "Payment Received"),
                new OrderStages(7, "Send Updated OC"),
                new OrderStages(8, "Prepare DN & PL"),
                new OrderStages(9, "Pack Order"),
                new OrderStages(10, "Send INV & Shipping Docs"),
                new OrderStages(11, "Executed Pickup Date"),
                new OrderStages(12, "Order Pickup")
            };
            }
            return _orderStages;
        }
    }
}