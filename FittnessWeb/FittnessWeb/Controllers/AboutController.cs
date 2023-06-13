﻿using FittnessWeb.DAL;
using FittnessWeb.Models;
using FittnessWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FittnessWeb.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _db;
        public AboutController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            AboutVM aboutVM = new AboutVM()
            {
                Services = await _db.Services.ToListAsync()
            };
            return View(aboutVM);
        }
        public IActionResult Pricing()
        {
            return View();
        }
        public IActionResult Trainer()
        {
            return View();
        }
    }
}
