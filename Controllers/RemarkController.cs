using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProjectSoftware.Models;
using FinalProjectSoftware.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectSoftware.Controllers
{
    public class RemarkController : Controller
    {
        private readonly IRemark remark;
        public RemarkController(IRemark remark)
        {
            this.remark = remark;
        }
        // GET: Remark
        public ActionResult Index()
        {
            var result = remark.GetRemarks();
            return View(result);
        }

        // GET: Remark/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = remark.GetRemark(id);
            return View(entity);
        }

        // GET: Remark/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Remark/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Remark obj)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add insert logic here
                    remark.Create(obj);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {

                    return View(ex.Message);
                }

            }
            return View(ModelState.ErrorCount);
        }

        // GET: Remark/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var choice = remark.GetRemark(id);
            if (choice == null)
            {
                return NotFound();
            }
            return View(choice);
        }

        // POST: Remark/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Remark obj)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add update logic here
                    remark.Update(id, obj);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    return View(ex.Message);
                }
            }
            return View(ModelState.ErrorCount);

        }

        // GET: Remark/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var choice = remark.GetRemark(id);
            if (choice == null)
            {
                return NotFound();
            }
            return View(choice);
        }

        // POST: Remark/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                remark.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                return View(ex.Message);
            }
        }
    }
}
