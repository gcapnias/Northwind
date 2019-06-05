using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Northwind.BindingModels;
using Northwind.Models;
using Northwind.Repositories;
using Northwind.ViewModels;

namespace Northwind.Website.Controllers
{
    public class OrdersController : Controller
    {
        NorthwindEntities _db = null;

        public OrdersController()
        {
            _db = new NorthwindEntities();
        }

        // GET: Orders
        public ActionResult Index()
        {
            OrdersRepository r = new OrdersRepository(_db);
            IEnumerable<OrderViewModel> model = r.GetViewModels();

            return View(model);
        }

        // GET: Orders/Details/5
        public ActionResult Details(int id)
        {
            OrdersRepository r = new OrdersRepository(_db);
            Order model = r.GetById(id);

            return View(model);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        [HttpPost]
        public ActionResult Create(OrderBindingModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    OrdersRepository r = new OrdersRepository(_db);
                    Order entity = new Order();

                    entity.CustomerID = model.CustomerID;
                    entity.EmployeeID = model.EmployeeID;
                    entity.Freight = model.Freight;
                    entity.OrderDate = model.OrderDate;
                    entity.RequiredDate = model.RequiredDate;
                    entity.ShipAddress = model.ShipAddress;
                    entity.ShipCity = model.ShipCity;
                    entity.ShipCountry = model.ShipCountry;
                    entity.ShipName = model.ShipName;
                    entity.ShippedDate = model.ShippedDate;
                    entity.ShipPostalCode = model.ShipPostalCode;
                    entity.ShipRegion = model.ShipRegion;
                    entity.ShipVia = model.ShipVia;

                    _db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                { }
            }

            return View(model);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int id)
        {
            OrdersRepository r = new OrdersRepository(_db);
            OrderBindingModel model = r.GetById(id).ToBindingModel();

            return View(model);
        }

        // POST: Orders/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, OrderBindingModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    OrdersRepository r = new OrdersRepository(_db);
                    Order entity = r.GetById(id);

                    entity.CustomerID = model.CustomerID;
                    entity.EmployeeID = model.EmployeeID;
                    entity.Freight = model.Freight;
                    entity.OrderDate = model.OrderDate;
                    entity.RequiredDate = model.RequiredDate;
                    entity.ShipAddress = model.ShipAddress;
                    entity.ShipCity = model.ShipCity;
                    entity.ShipCountry = model.ShipCountry;
                    entity.ShipName = model.ShipName;
                    entity.ShippedDate = model.ShippedDate;
                    entity.ShipPostalCode = model.ShipPostalCode;
                    entity.ShipRegion = model.ShipRegion;
                    entity.ShipVia = model.ShipVia;

                    _db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                }

            }

            return View(model);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Orders/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
