using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace myshop.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        Models.db db = new Models.db();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreateProduct()
        {
            return View();
        }
        [System.Web.Mvc.HttpPost]
        public ActionResult CreateProduct(Models.Product p1, HttpPostedFileBase ImageProduct)
        {
            string imageName = "nophoto.png";
            if (ImageProduct != null)
            {
                imageName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(ImageProduct.FileName);
                ImageProduct.SaveAs(System.Web.HttpContext.Current.Server.MapPath("/MyPictures/" + imageName));
            }
            p1.ImageProduct = imageName;
            var product = db.Products.Add(p1);
            db.SaveChanges();
            List<Models.CategoryName> CategoryNames = new List<Models.CategoryName>();
            if (Session["CategoryNames"] != null)
            {
                Models.ProductWithCategory pwc = new Models.ProductWithCategory();
                CategoryNames = Session["CategoryNames"] as List<Models.CategoryName>;
                foreach (var item in CategoryNames)
                {
                    pwc.IdCategoryName = item.IdCategoryName;
                    pwc.IdProduct = product.IdProduct;
                    db.ProductWithCategorys.Add(pwc);
                    db.SaveChanges();
                }

            }

            return RedirectToAction("CreateProduct");
        }
        public ActionResult CreateNewCategory(Models.CategoryName c1)
        {
            db.CategoryNames.Add(c1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ShowAllProduct()
        {
            var q = db.Products.ToList();
            return View(q);
        }
        public ActionResult ShowAllCategory()
        {
            var q = db.CategoryNames.ToList();
            return View("ShowAllCategory" , q);
        }
        public ActionResult SelectCategory(int Id, string Subject)
        {
            List<Models.CategoryName> category_names = new List<Models.CategoryName>();
            if (Session["CategoryNames"] != null)
            {
                category_names = Session["CategoryNames"] as List<Models.CategoryName>;
            }
            int index = category_names.FindIndex(t => t.IdCategoryName == Id);
            if (index == -1)
            {
                category_names.Add(new Models.CategoryName()
                {
                    IdCategoryName = Id,
                    Subject = Subject
                });
            }
            Session["CategoryNames"] = category_names;

            return RedirectToAction("CreateProduct");
        }
        public ActionResult DeleteProduct(int id)
        {
            var q = from i in db.Products where i.IdProduct == id select i;
            var data = q.Single();
            db.Products.Remove(data);
            db.SaveChanges();
            return RedirectToAction("ShowAllProduct");
        }
        public ActionResult EditProduct(Models.Product p1 , HttpPostedFileBase ImageProduct)
        {
            string imageName = "nophoto.png";
            if (ImageProduct != null)
            {
                imageName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(ImageProduct.FileName);
                ImageProduct.SaveAs(System.Web.HttpContext.Current.Server.MapPath("/MyPictures/" + imageName));
            }
            var f = from i in db.Products where i.IdProduct == p1.IdProduct select i;
            var q = f.Single();
            q.Name = p1.Name;
            q.Price = p1.Price;
            q.PriceOffer = p1.PriceOffer;
            q.ImageProduct = imageName;
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }


    }
}