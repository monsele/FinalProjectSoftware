using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProjectSoftware.Models;
using FinalProjectSoftware.Services;
using FinalProjectSoftware.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FinalProjectSoftware.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IPlacement placement;
        private readonly IStatus statuss;
        private readonly IJobRole job;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IPlacement placement, IStatus status, IStatus statuss,IJobRole job)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.statuss = statuss;
            this.placement = placement;
            this.job = job;
        }
        public IActionResult Index()
        {
            var res = userManager.Users.ToList();
            return View(res);
        }
        public IActionResult Register()
        {
            RegisterViewModel model = new RegisterViewModel();
            model.Placements = placement.GetPlacements();
            model.JobRole = job.GetJobs();
            model.Statuses = statuss.GetStatuses();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                //model.ReturnUrl = returnUrl ?? Url.Content("~/");
                var user = new User
                {
                    UserName = model.FirstName,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    StateOfOrigin = model.StateOfOrigin,
                    JobRole = job.GetJob(model.JobRoleId),
                    Placement = placement.GetPlacement(model.PlacementId),
                    status = statuss.GetStatus(model.StatusId)
                };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                var error = result.Errors;
                return View(error.ToList());
            }
            RegisterViewModel rmodel = new RegisterViewModel();
            rmodel.Placements = placement.GetPlacements();
            rmodel.JobRole = job.GetJobs();
            rmodel.Statuses = statuss.GetStatuses();
            return View(rmodel);
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Username, model.Password, true, false);
                if (result.Succeeded)
                {
                    //logger.LogInformation("User Just Logged in");
                    return RedirectToAction("Index","Home");
                }
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
           // logger.LogInformation("User Logged out");
            return RedirectToAction("Login");
        }


    }
}