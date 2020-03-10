using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProjectSoftware.Models;
using FinalProjectSoftware.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectSoftware.Controllers
{
    public class ActivitityController : Controller
    {
        private readonly IActivity serve;
        private readonly IRemark remark;
        public ActivitityController(IActivity serve, IRemark remark)
        {
            this.serve = serve;
            this.remark = remark;
        }
        // GET: Activitity
        public ActionResult Index()
        {
            var results = serve.GetActivitities();
            return View(results);
        }

        // GET: Activitity/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var choice = serve.GetActivitity(id);
            return View(choice);
        }

        // GET: Activitity/Create
        public ActionResult Create(int Remarkid)
        {
            //ViewData["RemarkId"] = new SelectList(remark.dropdownlist(), "id", "remarkName",Remarkid);
            ViewBag.Remarks = remark.GetRemarks();
            return View();
        }

        // POST: Activitity/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Activitity activitity, int Remarkid)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add insert logic here
                    //activitity.Remark = remark.GetRemark(Remarkid);
                    serve.Create(activitity);
                    return RedirectToAction(nameof(Index));

                }
                catch (Exception ex)
                {
                    return View(ex.Message);
                }

            }
            return View(ModelState);

        }

        // GET: Activitity/Edit/5
        public ActionResult Edit(int? id, int? JobRoleId)
        {
            if (id == null)
            {
                return NotFound();
            }
            var choice = serve.GetActivitity(id);
            if (choice == null)
            {
                return NotFound();
            }
            ViewBag.Remarks = remark.GetRemarks();
            return View(choice);
        }

        // POST: Activitity/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Activitity activitity, int RemarkId, int? JobRoleId)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add update logic here
                    //activitity.Remark = remark.GetRemark(RemarkId);
                    serve.Update(id, activitity);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                
                {

                    return View(ex.Message);
                }
            }
            return View(ModelState);
        }

        // GET: Activitity/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return View();
        }

        // POST: Activitity/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                serve.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}
