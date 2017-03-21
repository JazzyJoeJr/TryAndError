using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult Index(int id)
        {
            StitchJobsListVM stitchJobsListVM = new StitchJobsListVM();
            stitchJobsListVM.stitchJobsList = _context.Stitches.Where(e => e.MachineId == id).Include(m => m.Machine).ToList();
            return View(stitchJobsListVM);
        }
        public IActionResult Out(int id)
        {
            Stitch s = new Stitch();
            s = _context.Stitches.FirstOrDefault(e => e.Id == id);
            s.MachineId = 1;
            _context.Entry(s).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            StitchJobsListVM stitchJobsListVM = new StitchJobsListVM();
            stitchJobsListVM.stitchJobsList = _context.Stitches.Where(e => e.MachineId == 1).ToList();
            return View("Index", stitchJobsListVM);
        }
        public IActionResult PlanStitch1(int id)
        {
            Stitch s = new Stitch();
            s = _context.Stitches.FirstOrDefault(e => e.Id == id);
            s.MachineId = 2;
            _context.Entry(s).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return RedirectToAction("Index", 1);
        }
        public IActionResult PlanStitch2(int id)
        {
            Stitch s = new Stitch();
            s = _context.Stitches.FirstOrDefault(e => e.Id == id);
            s.MachineId = 3;
            _context.Entry(s).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return RedirectToAction("Index", 1);
        }
        public IActionResult PlanStitch3(int id)
        {
            Stitch s = new Stitch();
            s = _context.Stitches.FirstOrDefault(e => e.Id == id);
            s.MachineId = 4;
            _context.Entry(s).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return RedirectToAction("Index", 1);
        }
        public IActionResult PlanStitch4(int id)
        {
            Stitch s = new Stitch();
            s = _context.Stitches.FirstOrDefault(e => e.Id == id);
            s.MachineId = 2;
            _context.Entry(s).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return RedirectToAction("Index", 1);
        }
    }
}
