using PharmaAssist2._0.Models;
using PharmaAssist2._0.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PharmaAssist2._0.Controllers
{
    public class CartController : Controller
    {
        CartRepository contex = new CartRepository();
        // GET: Cart
        public ActionResult Add(Cart cart)
        {
            if (Session["logged_id"] == null || Session["logged_type"] == null || !Session["logged_type"].Equals("Consumer"))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                // Session["logged_id"] = 1;
                cart.Totalprice = (cart.Price * cart.Quantity);
                cart.ConsumerId = (int)Session["logged_id"];
                var q = new Cart();
                q = contex.Check(cart.ConsumerId, cart.ProductId);
                if (q == null)
                {
                    contex.Insert(cart);
                }
                else
                {
                    return RedirectToAction("Index", "Product");
                }



                return RedirectToAction("Index", "Product");
            }
        }
        public ActionResult ShowCart()
        {

          //  Session["logged_id"] = 1;



            return View(contex.ShowCart((int)Session["logged_id"]));
        }
        public ActionResult Delete(int id)
        {


            contex.Delete(id);

            return View("ShowCart");
        }
    }
}