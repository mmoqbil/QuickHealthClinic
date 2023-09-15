﻿using Microsoft.AspNetCore.Mvc;

namespace QuickLifeCoachingClinic.Controllers
{
    [ApiController]
    [Route("/api/referrals")]
    public class ReferralController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
