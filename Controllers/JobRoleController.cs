using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProjectSoftware.Models;
using FinalProjectSoftware.Services;
using FinalProjectSoftware.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectSoftware.Controllers
{
    public class JobRoleController : Controller
    {
        private readonly IJobRole serve;
        private readonly IActivity activitity;
        private readonly IRemark remark;
        public JobRoleController(IJobRole serve, IActivity activitity, IRemark remark)
        {
            this.serve = serve;
            this.activitity = activitity;
            this.remark = remark;
        }
        // GET: JobRole
        public ActionResult Index()
        {
            var result = serve.GetJobs();
            return View(result);
        }

        // GET: JobRole/Details/5
        public ActionResult Details(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            var choice = serve.GetJob(id);
            if (choice==null)
            {
                return NotFound();
            }
            return View(choice);
        }

        // GET: JobRole/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Job/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JobRole job)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add insert logic here
                    serve.Create(job);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    return View(ex.Message);
                }
            }
            return View(ModelState.ErrorCount);
        }

        // GET: Job/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var choice = serve.GetJob(id);
            if (choice == null)
            {
                return NotFound();
            }
            return View(choice);
        }

        // POST: Job/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, JobRole job)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add update logic here
                    serve.Update(id, job);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    return View(ex.Message);
                }
            }
            return View(ModelState.ErrorCount);
        }

        // GET: Job/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var choice = serve.GetJob(id);
            if (choice == null)
            {
                return NotFound();
            }
            return View(choice);
        }

        // POST: Job/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(JobRole job)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add delete logic here
                    serve.Delete(job);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    return View(ex.Message);
                }
            }
            return View(ModelState.ErrorCount);
        }

        private JobActivityViewModel GetJobActivityViewModel(JobRole job)
        {
            JobActivityViewModel viewModel = new JobActivityViewModel();
            viewModel.Job = job;
            viewModel.Activitities = activitity.GetActivitiesByJob(job);
            return viewModel;
        }

        public IActionResult DetailsView(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            JobRole jobPick = serve.GetJob(id);
            if (jobPick==null)
            {
                return NotFound();
            }
            JobActivityViewModel vm = GetJobActivityViewModel(jobPick);
            vm.Job = jobPick;
            vm.GetRemarks = remark.GetRemarks();
            vm.Activitities = activitity.GetActivitiesByJob(jobPick);
            ViewBag.Remarks = vm.GetRemarks;
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DetailsView(JobActivityViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Activitity act = new Activitity
                {
                    Name = vm.Name,
                    Date = vm.Date,
                    Description = vm.Description,
                    RemarkId=vm.RemarkId,
                    Remark =remark.GetRemark(vm.RemarkId),
                    JobRole=vm.Job
                };
                JobRole role = serve.GetJobByActivity(vm);
                if (role==null)
                {
                    return NotFound();
                }
                vm.Job = role;
                act.JobRole = role;
                activitity.Create(act);
                vm = GetJobActivityViewModel(role);

                vm.JobId = role.Id;
                //return RedirectToAction("Index");
                return View(vm);
            }
            return View(vm);
        }
    }
}