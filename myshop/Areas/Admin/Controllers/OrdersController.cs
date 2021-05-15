using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace myshop.Areas.Admin.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Admin/Orders
        Models.db db = new Models.db();
        public ActionResult main()
        {
            return View();
        }
        public ActionResult AllOrders()
        {
            var data =  db.Payments.ToList();
            return PartialView(data);
        }
        public ActionResult UserInformation(int id)
        {
            var q = from i in db.myusers where i.UserId == id select i;
            var user = q.Single();
            return View(user);
        }
        public ActionResult PaymentdetailsUser(int id)
        {
            var q = from i in db.paymentdetails where i.IdPayment == id select i;
            var data = q.ToList();
            return View(data);
        }
    }
}