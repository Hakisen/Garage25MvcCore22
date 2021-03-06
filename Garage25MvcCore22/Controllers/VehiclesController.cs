﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Garage25MvcCore22.Models;

namespace Garage25MvcCore22.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly Garage25MvcCore22Context _context;

        public VehiclesController(Garage25MvcCore22Context context)
        {
            _context = context;
        }

        // GET: Vehicles
        public async Task<IActionResult> Index(string SearchString)
        {
            var garage25MvcCore22Context = _context.Vehicle.Include(v => v.Member).Include(v => v.VehicleType).ToListAsync();

            if (!string.IsNullOrEmpty(SearchString))
            {
                garage25MvcCore22Context = _context.Vehicle.Include(v => v.Member).Include(v => v.VehicleType).Where(vv=>vv.RegNr.Contains(SearchString)).ToListAsync();

            }

            return View(await garage25MvcCore22Context);

            //   var EndTime = DateTime.Now;
            //var Results = from m in _context.Member
            //              join v in _context.Vehicle on m.Id equals v.MemberId 
            //              join t in _context.VehicleType on v.VehicleTypeId equals t.Id
            //              orderby v.MemberId descending
            //              select new VehicleOverviewViewModel
            //              {
            //                  Member = m,
            //                  VehicleType=t,
            //                  RegNr=v.RegNr,
            //                  VehicleId = v.Id,
            //                  StartTime=v.StartTime
            //              };
            //   if (!string.IsNullOrEmpty(SearchString))
            //   {
            //       SearchString = SearchString.ToUpper();
            //       Results = from m in _context.Member
            //                 join v in _context.Vehicle on m.Id equals v.MemberId
            //                 join t in _context.VehicleType on v.VehicleTypeId equals t.Id
            //                 where (v.RegNr.Contains(SearchString) || v.VehicleType.Type.Contains(SearchString))
            //                 select new VehicleOverviewViewModel
            //                 {
            //                     Member = m,
            //                     VehicleType = t,
            //                     RegNr = v.RegNr,
            //                     VehicleId = v.Id,
            //                     StartTime = v.StartTime
            //                 };
            //       }

          //  return View(Results);
    }


//        from d in Duty
//join c in Company on d.CompanyId equals c.id
//join s in SewagePlant on c.SewagePlantId equals s.id
// .Select(m => new
//  {
//      duty = s.Duty.Duty, 
//      CatId = s.Company.CompanyName,
//      SewagePlantName=s.SewagePlant.SewagePlantName
//        // other assignments
//    });

             public IActionResult VehicleMemberOverview(string SearchString)
        {
            //    var garage25MvcCore22Context = _context.Vehicle.Include(v => v.Member).Include(v => v.VehicleType);
            //    return View(await garage25MvcCore22Context.ToListAsync());

            var EndTime = DateTime.Now;
         var Results = from m in _context.Member
                       join v in _context.Vehicle on m.Id equals v.MemberId 
                       join t in _context.VehicleType on v.VehicleTypeId equals t.Id
                       where(v.Parked == true)
                       orderby v.MemberId descending
                       select new VehicleOverviewViewModel
                       {
                           Member = m,
                           VehicleType=t,
                           RegNr=v.RegNr,
                           VehicleId = v.Id,
                           StartTime=v.StartTime
                       };
            if (!string.IsNullOrEmpty(SearchString))
            {
                SearchString = SearchString.ToUpper();
                Results = from m in _context.Member
                          join v in _context.Vehicle on m.Id equals v.MemberId
                          join t in _context.VehicleType on v.VehicleTypeId equals t.Id
                          where (v.RegNr.Contains(SearchString) || v.VehicleType.Type.Contains(SearchString) && v.Parked==true)
                          select new VehicleOverviewViewModel
                          {
                              Member = m,
                              VehicleType = t,
                              RegNr = v.RegNr,
                              VehicleId = v.Id,
                              StartTime = v.StartTime
                          };
                }
           
            return View(Results);
    }
        // GET: Vehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle
                .Include(v => v.Member)
                .Include(v => v.VehicleType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // GET: Vehicles/Create
        public IActionResult Create()
        {
            ViewData["MemberId"] = new SelectList(_context.Member, "Id", "Name");
            ViewData["VehicleTypeId"] = new SelectList(_context.Set<VehicleType>(), "Id", "Type");
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RegNr,NrOfWheels,Color,Model,Brand,StartTime,Parked,VehicleTypeId,MemberId")] Vehicle vehicle)
        {
            vehicle.RegNr = vehicle.RegNr.ToUpper();

            if (ModelState.IsValid)
            {
                vehicle.StartTime = DateTime.Now;
                vehicle.Parked = true;
                _context.Add(vehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MemberId"] = new SelectList(_context.Member, "Id", "Name", vehicle.MemberId);
            ViewData["VehicleTypeId"] = new SelectList(_context.Set<VehicleType>(), "Id", "Type", vehicle.VehicleTypeId);
            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            ViewData["MemberId"] = new SelectList(_context.Member, "Id", "Name", vehicle.MemberId);
            ViewData["VehicleTypeId"] = new SelectList(_context.Set<VehicleType>(), "Id", "Type", vehicle.VehicleTypeId);
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RegNr,NrOfWheels,Color,Model,Brand,StartTime,Parked,VehicleTypeId,MemberId")] Vehicle vehicle)
        {
            if (id != vehicle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(vehicle.Id))
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
            ViewData["MemberId"] = new SelectList(_context.Member, "Id", "N" +
                "ame", vehicle.MemberId);
            ViewData["VehicleTypeId"] = new SelectList(_context.Set<VehicleType>(), "Id", "Type", vehicle.VehicleTypeId);
            return View(vehicle);
        }

        public async Task<IActionResult> CheckIn(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            vehicle.Parked = true;
            vehicle.StartTime = DateTime.Now;
            _context.Vehicle.Update(vehicle);
            await _context.SaveChangesAsync();

            TempData["ParkedOk"] = $"Vehcile; reg.Nr. {vehicle.RegNr} succefully parked";
            return RedirectToAction("VehicleMemberOverview");

        }

        public async Task<IActionResult> CheckOut(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle
                .Include(v => v.Member)
                .Include(v => v.VehicleType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            if (vehicle.Parked == false)
            {
                TempData["NotParked"] = "Vehicle Is Not Parked";
                return RedirectToAction("VehicleMemberOverview");
            }

            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("CheckOut")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CheckOutConfirmed(int id)
        {
            Receipt receipt = new Receipt();

            //var receipts = _context.Receipt.ToListAsync();

            var vehicle = _context.Vehicle.Include(m => m.Member).FirstOrDefault(p => p.Id == id);            
            receipt.RegNr = vehicle.RegNr;
            receipt.MemberName = vehicle.Member.Name;
            receipt.StartTime = vehicle.StartTime;
            receipt.EndTime = DateTime.Now;

            var between = receipt.EndTime.Subtract(receipt.StartTime);
            receipt.parkedTime= (int)Math.Round(between.TotalMinutes) ;
            var days = receipt.parkedTime / 24 * 3600;
            var hours = receipt.parkedTime / 60;
            var minutes = receipt.parkedTime;
           
            receipt.ParkedTimeFormatted = string.Format("{0} days, {1} hrs, {2} min", between.Days, between.Hours, between.Minutes);
            receipt.TotalPrice = (receipt.parkedTime) *1;

            vehicle.Parked = false;
            _context.Vehicle.Update(vehicle);
            _context.Receipt.Add(receipt);
           
            await _context.SaveChangesAsync();

            return View("CheckOutReceipt", receipt);
        }


        // GET: Vehicles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle
                .Include(v => v.Member)
                .Include(v => v.VehicleType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicle = await _context.Vehicle.FindAsync(id);
            _context.Vehicle.Remove(vehicle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleExists(int id)
        {
            return _context.Vehicle.Any(e => e.Id == id);
        }
    }
}
