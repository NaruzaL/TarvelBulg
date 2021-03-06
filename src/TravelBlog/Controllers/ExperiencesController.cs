﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelBlog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace TravelBlog.Controllers
{
    public class ExperiencesController : Controller
    {

        private readonly TravelBlogContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public ExperiencesController(UserManager<ApplicationUser> userManager, TravelBlogContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            return View(_db.Experiences.Where(x => x.User.Id == currentUser.Id));
        }
        public IActionResult Create()
        {
            ViewBag.LocationId = new SelectList(_db.Locations, "LocationId", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Experience experience, int locationId)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            var thisLocation = _db.Locations.FirstOrDefault(locations => locations.LocationId == locationId);
            experience.Location = thisLocation;
            experience.User = currentUser;
            _db.Experiences.Add(experience);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var thisExperience = _db.Experiences.Include(experiences => experiences.People).FirstOrDefault(experiences => experiences.ExperienceId == id);
            return View(thisExperience);
        }
        //Create 
      
        public IActionResult Edit(int id)
        {
            var thisExperience = _db.Experiences.FirstOrDefault(experiences => experiences.ExperienceId == id);
            ViewBag.LocationId = new SelectList(_db.Locations, "LocationId", "Name");
            return View(thisExperience);
        }
        [HttpPost]
        public IActionResult Edit(Experience experience)
        {
            _db.Entry(experience).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Delete
        public ActionResult Delete(int id)
        {
            var thisExperience = _db.Experiences.FirstOrDefault(experiences => experiences.ExperienceId == id);
            return View(thisExperience);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisExperience = _db.Experiences.FirstOrDefault(experiences => experiences.ExperienceId == id);
            _db.Experiences.Remove(thisExperience);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
