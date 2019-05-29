﻿using BAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.ViewModels.CommodityViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class CommodityController:Controller
    {
        private readonly ICommodityManager commodityManager;

        private readonly IModeratorManager moderatorManager;

        public CommodityController(ICommodityManager commodityManager, IModeratorManager moderatorManager)
        {
            this.commodityManager = commodityManager;
            this.moderatorManager = moderatorManager;
        }
        [Authorize(Roles = "Moderator")]
        [HttpPost]
        public IActionResult AddCommodity(CommodityViewModel item)
        {

            item.ModeratorId =moderatorManager.GetThisModerator(this.User.FindFirstValue(ClaimTypes.NameIdentifier)).Id;
          
            commodityManager.Insert(item);
            return RedirectToAction("Index", "Commodity");
        }
        [Authorize(Roles = "Moderator")]
        [HttpGet]
        public IActionResult AddCommodity()
        {
            return View();
        }
        [Authorize(Roles = "Moderator,Admin")]
        [HttpGet]
        public IActionResult DeleteConfirmed(int Id)
        {

            commodityManager.Delete(Id);
            return RedirectToAction("Index", "Commodity");
        }
        [Authorize(Roles = "Moderator,Admin")]
        [HttpPost]
        public IActionResult Delete(int commodityId)
        {
            var commodity = commodityManager.Get(commodityId);

            if (commodity == null)
            {
                return NotFound();
            }
            return View(commodity);
        }
        [Authorize(Roles = "Moderator")]
        [HttpPost]
        public IActionResult Edit(CommodityViewModel item)
        {

            if (ModelState.IsValid)
            {
                commodityManager.Update(item);
                return RedirectToAction("Index");
            }
            return View(item);
        }
        [Authorize(Roles = "Moderator")]
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var commodity = commodityManager.Get(Id);

            if (commodity == null)
            {
                return NotFound();
            }
            return View(commodity);
        }

        [Authorize(Roles = "Moderator")]
        [HttpGet]
        public IActionResult Index()
        {

            var coms = commodityManager.GetModeratorCommodities(moderatorManager.GetThisModerator(
                       this.User.FindFirstValue(ClaimTypes.NameIdentifier)).Id);
            return View(coms);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult IndexAdmin()
        {
            return View(commodityManager.GetCommodities());
        }

        [Authorize(Roles = "Moderator,Admin")]
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public IActionResult Details(int commodityId)
        {
            return View(commodityManager.Get(commodityId));
        }

        [Authorize(Roles = "Moderator,Admin,User")]
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public IActionResult ShowCommodities()
        {
           var comms= commodityManager.GetUserCommodities();
            return View(comms);
        }
    }
}
