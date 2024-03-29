﻿using System;
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
    public class ProjectsController : Controller
    {
        private readonly ProjectDbContext _context;
        private readonly OrgDbContext _orgcontext;
        private readonly ApplicationDbContext _appcontext;

        List<Organizations> orgList = new List<Organizations>();
        List<Project> projList = new List<Project>();
        List<ApplicationUser> userList = new List<ApplicationUser>();

        public ProjectsController(ProjectDbContext context, OrgDbContext orgcontext, ApplicationDbContext appcontext)
        {
            _context = context;
            _orgcontext = orgcontext;
            _appcontext = appcontext;
        }

        
        public List<ProjectFullView> GetFullProjectView()
        {
            orgList = (from o in _orgcontext.Organizations orderby o.OrgName select o).ToList();
            projList = (from p in _context.Project orderby p.ProjectId select p).ToList();
            userList = (from u in _appcontext.Users orderby u.LastName select u).ToList();

            //List<ProjectFullView> fullView = new List<ProjectFullView>();
            var fullView = (from p in projList
                            join o in orgList on p.ClientId equals o.OrgID
                            join u in userList on p.LeaderID equals u.NormalizedUserName
                            select new ProjectFullView { ProjectVm = p, OrgVm = o, UserVm = u }).ToList();

            return fullView;
        }

        
        // GET: Projects
        public ActionResult Index()
        {
            var data = GetFullProjectView();
            return View(data);
        }


        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project
                .FirstOrDefaultAsync(m => m.ProjectId == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            orgList = (from o in _orgcontext.Organizations orderby o.OrgName select o).ToList();
            orgList.Insert(0, new Organizations { OrgID = 0, OrgName = " -- Select Client -- " });
            ViewBag.ListOfOrgs = orgList;


            userList = (from u in _appcontext.Users orderby u.LastName select u).ToList();
            userList.Insert(0, new ApplicationUser { NormalizedUserName = "", FirstName = " -- Select", LastName = "Project Lead --" });
            ViewBag.ListOfUsers = userList;

            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectId,ProjectName,ProjectDesc,ProjectLongdesc,ProjectStartDate,ProjectStatus,LeaderID,ClientId,HoursProjected,HoursUsed")] Project project)
        {
            if (ModelState.IsValid)
            {
                _context.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            orgList = (from o in _orgcontext.Organizations orderby o.OrgName select o).ToList();
            orgList.Insert(0, new Organizations { OrgName = " -- Select Client -- " });
            ViewBag.ListOfOrgs = orgList;

            userList = (from u in _appcontext.Users orderby u.LastName select u).ToList();
            userList.Insert(0, new ApplicationUser { NormalizedUserName = "", FirstName = " -- Select", LastName = "Project Lead --" });
            ViewBag.ListOfUsers = userList;

            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectId,ProjectName,ProjectDesc,ProjectLongDesc,ProjectStartDate,ProjectStatus,LeaderID,ClientId,HoursProjected,HoursUsed")] Project project)
        {
            if (id != project.ProjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.ProjectId))
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
            return View(project);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project
                .FirstOrDefaultAsync(m => m.ProjectId == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project = await _context.Project.FindAsync(id);
            _context.Project.Remove(project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id)
        {
            return _context.Project.Any(e => e.ProjectId == id);
        }
    }
}
