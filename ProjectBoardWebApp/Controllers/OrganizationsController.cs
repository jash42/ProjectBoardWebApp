using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectBoardWebApp.Data;
using ProjectBoardWebApp.Models;

namespace ProjectBoardWebApp.Controllers
{
    public class OrganizationsController : Controller
    {
        private readonly OrgDbContext _context;

        public OrganizationsController(OrgDbContext context)
        {
            _context = context;
        }

        // GET: Organizations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Organizations.ToListAsync());
        }

        // GET: Organizations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizations = await _context.Organizations
                .FirstOrDefaultAsync(m => m.OrgID == id);
            if (organizations == null)
            {
                return NotFound();
            }

            return View(organizations);
        }

        // GET: Organizations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Organizations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrgID,OrgName,OrgAddress,OrgAddress2,OrgCity,OrgState,OrgZip,OrgPhone,OrgWebsite,MainContact,StagingUrl")] Organizations organizations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(organizations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(organizations);
        }

        // GET: Organizations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizations = await _context.Organizations.FindAsync(id);
            if (organizations == null)
            {
                return NotFound();
            }
            return View(organizations);
        }

        // POST: Organizations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrgID,OrgName,OrgAddress,OrgAddress2,OrgCity,OrgState,OrgZip,OrgPhone,OrgWebsite,MainContact,StagingUrl")] Organizations organizations)
        {
            if (id != organizations.OrgID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(organizations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganizationsExists(organizations.OrgID))
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
            return View(organizations);
        }

        // GET: Organizations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizations = await _context.Organizations
                .FirstOrDefaultAsync(m => m.OrgID == id);
            if (organizations == null)
            {
                return NotFound();
            }

            return View(organizations);
        }

        // POST: Organizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var organizations = await _context.Organizations.FindAsync(id);
            _context.Organizations.Remove(organizations);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrganizationsExists(int id)
        {
            return _context.Organizations.Any(e => e.OrgID == id);
        }
    }
}
