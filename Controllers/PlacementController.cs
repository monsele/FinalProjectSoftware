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
    public class PlacementController : Controller
    {
        private readonly IPlacement placement;
        public PlacementController(IPlacement placement)
        {
            this.placement = placement;
        }
        // GET: Placement
        public ActionResult Index()
        {
            var result = placement.GetPlacements();
            return View(result);
        }

        // GET: Placement/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var choice = placement.GetPlacement(id);
            return View(choice);
        }

        // GET: Placement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Placement/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "<Pending>")]
        public ActionResult Create(Placement obj)
        {
            try
            {
                // TODO: Add insert logic here
                placement.Create(obj);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        // GET: Placement/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var choice = placement.GetPlacement(id);
            if (choice == null)
            {
                return NotFound();
            }
            return View(choice);
        }

        // POST: Placement/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Placement obj)
        {
            try
            {
                // TODO: Add update logic here
                placement.Update(id, obj);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        // GET: Placement/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var choice = placement.GetPlacement(id);
            if (choice == null)
            {
                return NotFound();
            }
            return View(choice);
        }

        // POST: Placement/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here
                placement.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}