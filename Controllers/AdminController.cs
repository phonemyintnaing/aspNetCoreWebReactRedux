﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InitCMS.Data;
using InitCMS.Models;
using InitCMS.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace InitCMS.Controllers
{
    public class AdminController : Controller
    {
       
        private readonly InitCMSContext _context;
        
        public AdminController(InitCMSContext context)
        {
            _context = context;
        }
        public ActionResult Login( )
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel ur)
        {
            if (ModelState.IsValid)
            {
                var tempUser = _context.User.FirstOrDefault(u => u.UserEmail == ur.Email && u.UserPassword == ur.Password);
               // var tempUser = _context.User.FirstOrDefault(u => u.UserEmail == "admin@init.com" && u.UserPassword == "1234");
                if (tempUser == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid Login Attempt!");
                    return View(ur);
                }                
            }
            //Add Session
            HttpContext.Session.SetString("SessionEmail", ur.Email);
            return RedirectToAction("Index", "Home");
        }
     
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Admin");
        }
    }
}
