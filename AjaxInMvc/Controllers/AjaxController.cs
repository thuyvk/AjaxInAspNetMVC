using AjaxInMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjaxInMvc.Controllers
{
    public class AjaxController : Controller
    {
        
        public List<Product> InitData()
        {
            List<Product> prodList = new List<Product>();

            Product p1 = new Product { ProdCode = "P001", ProdName = "Mobile", ProdQty = 75 };
            Product p2 = new Product { ProdCode = "P002", ProdName = "Laptop", ProdQty = 125 };
            Product p3 = new Product { ProdCode = "P003", ProdName = "Netbook", ProdQty = 100 };
            prodList.Add(p1);
            prodList.Add(p2);
            prodList.Add(p3);

            return prodList;
        }

        // GET: Ajax
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public PartialViewResult ShowDetails()
        {
            System.Threading.Thread.Sleep(3000); //DEMO ONLY
            string code = Request.Form["ProductCode"];
            var products = InitData();
            Product objView = products.Where(x => x.ProdCode == code).FirstOrDefault();
            return PartialView("_ShowDetails", objView);
        }

        public PartialViewResult GetAllProducts()
        {
            System.Threading.Thread.Sleep(3000); //DEMO ONLY
            List<Product> prodList = InitData();
            return PartialView("_GetAllProducts", prodList);
        }
    }
}