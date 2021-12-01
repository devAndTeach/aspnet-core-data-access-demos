using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFWebApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace EFWebApp.Controllers
{
    public class HumanResourcesController : Controller
    {
        private HrContext _context;

        public HumanResourcesController(HrContext db)
        {
            _context = db;

        }
        public IActionResult Candidates()
        {
            return View(_context.Candidates.ToList());
        }
    }
}