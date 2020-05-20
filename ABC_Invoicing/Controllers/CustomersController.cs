using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ABC_Invoicing.DAL;
using ABC_Invoicing.Models;
using ABC_Invoicing.UoW;

namespace ABC_Invoicing.Controllers
{
    public class CustomersController : Controller
    {
        public CustomersController() { }

        //private ABCInvoicingDbContext db = new ABCInvoicingDbContext();

        private readonly UnitofWork UoW;

        public CustomersController(UnitofWork UoW)
        {
            this.UoW = UoW;
        }


        // GET: Customers
        public ActionResult Index()
        {
            var customers = UoW.Repository<Customer>().GetAll().ToList();
            return View(customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = UoW.Repository<Customer>().GetById(x => x.CustomerID == id); //db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,CompanyName,CustomerAddress,CustomerPhone,CustomerRegNum,CustomerVatNumber,CustomerContact")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                UoW.Repository<Customer>().Insert(customer);
                UoW.SaveChanges();
                //db.Customers.Add(customer);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = UoW.Repository<Customer>().GetById(x => x.CustomerID == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,CompanyName,CustomerAddress,CustomerPhone,CustomerRegNum,CustomerVatNumber,CustomerContact")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                UoW.Repository<Customer>().Update(customer);
                UoW.SaveChanges();

                //db.Entry(customer).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = UoW.Repository<Customer>().GetById(x => x.CustomerID == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = UoW.Repository<Customer>().GetById(x => x.CustomerID == id);
            UoW.Repository<Customer>().Delete(customer);
            UoW.SaveChanges();
            //db.Customers.Remove(customer);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
