using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZwartOpWit.Models;
using ZwartOpWit.Models.Viewmodels;

namespace ZwartOpWit.Controllers
{
    public class StitchController: Controller
    {
        private readonly AppDBContext _context;

        public StitchController(AppDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            StitchJobsListVM stitchJobsListVM = new StitchJobsListVM();
            stitchJobsListVM.stitchJobsList = _context.Stitches.ToList();
            return View(stitchJobsListVM);
        }
    }
}
