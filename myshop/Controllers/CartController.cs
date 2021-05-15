using myshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace myshop.Controllers
{
    public class CartController : Controller
    {
        Models.db db = new Models.db();
        // GET: Cart
        public ActionResult MyCart()
        {
            return View();
        }
        public void AddToCart(Models.Product p1)
        {
            List<Models.Product> listproduct = new List<Models.Product>();
            if (Session["Cart"] != null)
            {
                listproduct = Session["Cart"] as List<Models.Product>;
            }
            int index = listproduct.FindIndex(t => t.IdProduct == p1.IdProduct);
            if (index == -1)
            {
                listproduct.Add(new Models.Product()
                {
                    Name = p1.Name,
                    IdProduct = p1.IdProduct,
                    NumbersOfProduct = p1.NumbersOfProduct,
                    Price = p1.Price,
                    ImageProduct = p1.ImageProduct

                });
            }
            Session["Cart"] = listproduct;
        }
        public ActionResult ShowMyCart()
        {
            List<Models.Product> listproduct = new List<Models.Product>();
            if (Session["Cart"] != null)
            {
                listproduct = Session["Cart"] as List<Models.Product>;
            }
            return PartialView(listproduct);
        }
        public ActionResult AddToPayment(Models.Payment pa1)
        {
            var PayId = db.Payments.Add(pa1);
            db.SaveChanges();
            List<Models.Product> listproduct = new List<Models.Product>();
            if (Session["Cart"] != null)
            {
                PaymentDetail pd1 = new PaymentDetail();
                listproduct = Session["Cart"] as List<Models.Product>;
                foreach (var item in listproduct)
                {
                    pd1.IdProduct = item.IdProduct;
                    pd1.ProductPrice = item.Price;
                    pd1.NumbersOfProduct = item.NumbersOfProduct;
                    pd1.IdPayment = PayId.IdPayment;
                    db.paymentdetails.Add(pd1);
                    db.SaveChanges();
                }             
            }
            return View();
        }
        public ActionResult DeleteSelectedCart(int id)
        {
            List<Models.Product> listproduct = new List<Models.Product>();
            if (Session["Cart"] != null)
            {
                listproduct = Session["Cart"] as List<Models.Product>;
            }
            var product = listproduct.FirstOrDefault(t => t.IdProduct == id);
            if (listproduct != null)
            {
                listproduct.Remove(product);

            }
            Session["Cart"] = listproduct;
            return RedirectToAction("MyCart");
        }
    }
}