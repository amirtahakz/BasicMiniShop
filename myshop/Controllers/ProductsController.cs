using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace myshop.Controllers
{
    public class ProductsController : Controller
    {
        Models.db db = new Models.db();
        // GET: Products
        public ActionResult Categorys()
        {
            return View();
        }
        public ActionResult AllProduct(int? Id)
        {
            if (Id == 0)
            {
                var AllProduct = db.Products.ToList();
                return PartialView(AllProduct);
            }
            else
            {
                var q = from i in db.ProductWithCategorys where i.IdCategoryName == Id select i.Product;
                var SelectedCategoryData = q.ToList();
                return PartialView(SelectedCategoryData);
            }

        }
        public ActionResult AllCategorysName()
        {
            var q = db.CategoryNames.ToList();
            return PartialView(q);
        }
        public ActionResult DetailsProduct(int? id)
        {
            var product = db.Products.Find(id);
            return View(product);
        }
        

    }
}