using DistributorMvcApp.DAL;
using DistributorMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DistributorMvcApp.Controllers
{
    public class DashboardController : Controller
    {
        static DistributorViewModel distributorViewModel;
        public DashboardController()
        {
            if (distributorViewModel == null)
            {
                distributorViewModel = new DistributorViewModel();
                distributorViewModel.Distributors = DALService.GetDistributors();
                distributorViewModel.OrderStages = DALService.GetOrderStages();
            }
        }
        // GET: Dashboard
        public ActionResult Index()
        {
            return View(distributorViewModel);
        }

        public ActionResult ShowpopUp(string type)
        {
            if (type == "Complete")
            {
                return PartialView("_CompletePopup");
            }
            return PartialView("_InProgressPopup");
        }

        [HttpPost]
        public ActionResult Save(List<Distributor> distributors)
        {
            distributorViewModel.Distributors = distributors;
            return Content("success");
        }


    }
}