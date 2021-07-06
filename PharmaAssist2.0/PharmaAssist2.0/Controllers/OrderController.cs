using PharmaAssist2._0.Models;
using PharmaAssist2._0.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PharmaAssist2._0.Controllers
{
    public class OrderController : Controller
    {

        CartRepository cartcontex = new CartRepository();
        OrderRepository contex = new OrderRepository();
        OrderDetailsRepository ordercontex = new OrderDetailsRepository();
        // GET: Order
        public ActionResult Add()
        {
           
            OrderDetail od = new OrderDetail();
            Order o = new Order();
            int totalprice = 0;

            Random rd = new Random();
            int rand_num = rd.Next(521400, 14785600);

            var invoice = "Pharma" + rand_num + "2021";

            var p = cartcontex.ShowCart((int)Session["logged_id"]);
            foreach (var c in p)
            {
                 totalprice = totalprice + c.Totalprice;
               

            }
            o.ConsumerId = (int)Session["logged_id"];
            o.InvoiceNumber = invoice;
            o.OrderDate = DateTime.Now;
            o.Totalprice = totalprice;
            o.StatusId = 2;
            contex.Insert(o);
            o = contex.GetId((int)Session["logged_id"], invoice);

            foreach (var c in p)
            {
                od.OrderId = o.Id;
                od.InvoiceNumber = invoice;
                od.ProductId = c.ProductId;
                od.Quantity = c.Quantity;
                od.ConsumerId = (int)Session["logged_id"];

                ordercontex.Insert(od);


            }










            return RedirectToAction("Index", "Product");
        }

        public ActionResult MyOrderHistory()
        {
           
            return View(contex.GetMyOrders((int)Session["logged_id"]));

        }
        public ActionResult MyOrderDetails(int id)
        {
            return View(ordercontex.GetInvoiceHistory(id));

        }
        public ActionResult Orderlist()
        {
            if (Session["logged_id"] == null || Session["logged_type"] == null || !Session["logged_type"].Equals("DeliveryMan"))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View(contex.GetAll());
            }

        }
        public ActionResult Status(int id)
        {
           var p= contex.Get(id);
            p.StatusId = 1;
            contex.Update(p);
            return RedirectToAction("Orderlist", "Order");

        }

    }
}