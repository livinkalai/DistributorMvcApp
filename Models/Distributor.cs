using DistributorMvcApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistributorMvcApp.Models
{
    public class Distributor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Order> Orders { get; set; }

        public Distributor()
        {
            Orders = new List<Order>();
        }

        public void FillEmpties()
        {
            IList<OrderStages> orderStages = DALService.GetOrderStages();
            foreach (OrderStages stage in orderStages)
            {
                Order order = Orders.FirstOrDefault(x => x.Id == stage.Id);
                if (order == null)
                {
                    Orders.Add(new Order(stage.Id, Status.Open));
                }
            }
            Orders = Orders.OrderBy(item => item.Id).ToList();
        }
    }

    public class Order
    {
        public int Id { get; set; }
        public Status Status { get; set; }

        public Order()
        {
            Status = Status.Open;
        }
        public Order(int id, Status status)
        {
            Id = id;
            Status = status;
        }
    }

    public class OrderStages
    {
        public string Title { get; set; }
        public int Id { get; set; }

        public OrderStages(int id, string title)
        {
            Id = id;
            Title = title;
        }
    }
    public enum Status
    {
        Open,
        InProgress,
        Completed
    }
}