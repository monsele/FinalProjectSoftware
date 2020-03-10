using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProjectSoftware.Models;
using FinalProjectSoftware.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectSoftware.Controllers
{
    public class StatusController : Controller
    {
        private readonly IStatus status;
        public StatusController(IStatus status)
        {
           this.status = status;
        }
        // GET: Status
        public ActionResult Index()
        {
            var result = status.GetStatuses();
            return View(result);
        }

        // GET: Status/Details/5
        public ActionResult Details(int id)
        {
            var res = status.GetStatus(id);
            return View(res);
        }

        // GET: Status/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Status/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Status obj)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add insert logic here
                    status.Create(obj);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    return View(ex.Message);
                }

            }
            var err = ModelState.Select(x => x.Value.Errors);
            return View(err);
        }

        // GET: Status/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var choice = status.GetStatus(id);
            if (choice == null)
            {
                return NotFound();
            }
            return View(choice);
        }

        // POST: Status/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Status obj)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add update logic here
                    status.Update(id, obj);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    return View(ex.Message);
                }
            }
            var err = ModelState.Select(x => x.Value.Errors);
            return View(err);
        }

        // GET: Status/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var choice = status.GetStatus(id);
            if (choice == null)
            {
                return NotFound();
            }
            return View(choice);

        }

        // POST: Status/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                status.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}