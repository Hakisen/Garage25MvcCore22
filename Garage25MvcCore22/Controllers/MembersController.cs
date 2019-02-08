using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Garage25MvcCore22.Models;

namespace Garage25MvcCore22.Controllers
{
    public class MembersController : Controller
    {
        private readonly Garage25MvcCore22Context _context;

        public MembersController(Garage25MvcCore22Context context)
        {
            _context = context;
        }

        // GET: Members
        public IActionResult Index(string SearchString)
        {
            // var model = await _context.Member.Include(v=>v.Vehicles).ToListAsync().GroupBy(g=>g.Id).Select;
            //if (!String.IsNullOrEmpty(SearchString))
            //{
            //    SearchString= SearchString.ToUpper();
            //    model = await _context.Member.Where(m => m.Name == SearchString).ToListAsync();

            //}

            //from m in _context.Member
            //                  join v in _context.Vehicle on m.Id equals v.MemberId into g
            //select new {  = p.Id, Count = g.Count() }
            
            var Results = from m in _context.Member
                          join v in _context.Vehicle on m.Id equals v.MemberId into VehiclesOwned
                          orderby m.Name ascending
                          select new MemberOverviewViewModel
                          {
                              Member = m,
                              Count = VehiclesOwned.Count()
                          };
            if (!String.IsNullOrEmpty(SearchString))
            {
                SearchString = SearchString.ToUpper();
                Results = from m in _context.Member
                              join v in _context.Vehicle on m.Id equals v.MemberId into VehiclesOwned
                              where (m.Name.Contains(SearchString))
                              orderby m.Id descending
                              select new MemberOverviewViewModel
                              {
                                  Member = m,
                                  Count = VehiclesOwned.Count()
                              };
            }

      



            return View(Results.ToList());
        }

       


        // GET: Members/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Member.Include(v=>v.Vehicles)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
            
        }

        // GET: Members/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,PhoneNr")] Member member)
        {
            if (ModelState.IsValid)
            {
                _context.Add(member);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }

        // GET: Members/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Member.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,PhoneNr")] Member member)
        {
            if (id != member.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(member);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberExists(member.Id))
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
            return View(member);
        }

        // GET: Members/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Member
                .FirstOrDefaultAsync(m => m.Id == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var member = await _context.Member.FindAsync(id);
            _context.Member.Remove(member);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemberExists(int id)
        {
            return _context.Member.Any(e => e.Id == id);
        }

      

    }
}
