using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectBoardWebApp.Areas.Identity.Data;
using ProjectBoardWebApp.Data;
using ProjectBoardWebApp.Models;
using ProjectBoardWebApp.ViewModel;

namespace ProjectBoardWebApp.Controllers
{
    public class WorkTasksController : Controller
    {
        private readonly WorkTaskDbContext _context;
        private readonly ProjectDbContext _projcontext;
        private readonly ApplicationDbContext _appcontext;

        List<Project> projectList = new List<Project>();
        List<ApplicationUser> userList = new List<ApplicationUser>();

        public WorkTasksController(WorkTaskDbContext context, ProjectDbContext projcontext, ApplicationDbContext appcontext)
        {
            _context = context;
            _projcontext = projcontext;
            _appcontext = appcontext;
        }

        // GET: WorkTasks
        public async Task<IActionResult> Index()
        {
            return View(await _context.WorkTask.ToListAsync());
        }

        // GET: WorkTasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workTask = await _context.WorkTask
                .FirstOrDefaultAsync(m => m.TaskID == id);
            if (workTask == null)
            {
                return NotFound();
            }

            return View(workTask);
        }

        // GET: WorkTasks/Create
        public IActionResult Create()
        {
            userList = (from u in _appcontext.Users orderby u.LastName select u).ToList();
            userList.Insert(0, new ApplicationUser { NormalizedUserName = "", FirstName = " -- Assign", LastName = "User --" });
            ViewBag.ListOfUsers = userList;

            projectList = (from p in _projcontext.Project orderby p.ProjectName select p).ToList();
            projectList.Insert(0, new Project { ProjectId = 0, ProjectName = " -- Select Project -- "});
            ViewBag.ListOfProjects = projectList;

            ViewBag.ListOfTasks = _context.WorkTask.ToList();

            return View();
        }

        // POST: WorkTasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaskID,ProjectID,ParentTask,TeamID,AssignedID,TaskName,TaskDesc,DateCreated,DateStarted,DateCompleted,HoursEstimated,HoursUsed")] WorkTask workTask)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workTask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workTask);
        }

        // GET: WorkTasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            userList = (from u in _appcontext.Users orderby u.LastName select u).ToList();
            userList.Insert(0, new ApplicationUser { NormalizedUserName = "", FirstName = " -- Assign", LastName = "User --" });
            ViewBag.ListOfUsers = userList;

            projectList = (from p in _projcontext.Project orderby p.ProjectName select p).ToList();
            projectList.Insert(0, new Project { ProjectId = 0, ProjectName = " -- Select Project -- " });
            ViewBag.ListOfProjects = projectList;

            ViewBag.ListOfTasks = _context.WorkTask.ToList();

            if (id == null)
            {
                return NotFound();
            }

            var workTask = await _context.WorkTask.FindAsync(id);
            if (workTask == null)
            {
                return NotFound();
            }
            return View(workTask);
        }

        // POST: WorkTasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaskID,ProjectID,ParentTask,TeamID,AssignedID,TaskName,TaskDesc,DateCreated,DateStarted,DateCompleted,HoursEstimated,HoursUsed")] WorkTask workTask)
        {
            if (id != workTask.TaskID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workTask);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkTaskExists(workTask.TaskID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(workTask);
        }

        // GET: WorkTasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workTask = await _context.WorkTask
                .FirstOrDefaultAsync(m => m.TaskID == id);
            if (workTask == null)
            {
                return NotFound();
            }

            return View(workTask);
        }

        // POST: WorkTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workTask = await _context.WorkTask.FindAsync(id);
            _context.WorkTask.Remove(workTask);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkTaskExists(int id)
        {
            return _context.WorkTask.Any(e => e.TaskID == id);
        }
    }
}
