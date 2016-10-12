using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class JobsController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Jobs
        [AllowAnonymous]
        public async Task<ActionResult> Index()
        {
            return View(await _db.Jobs.Include(j => j.Employer).ToListAsync());
        }

        // GET: Jobs/Details/5
        [AllowAnonymous]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = await _db.Jobs.FindAsync(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // GET: Jobs/Create
        public ActionResult Create()
        {
            var employers = _db.Employers.Select(e => new SelectListItem
            {
                Text = e.Name,
                Value = e.Id.ToString()
            });
            var vm = new JobViewModel
            {
                Employers = employers
            };
            return View(vm);
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Start,Finish,Title,EmployerId,Description")] JobViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var employer = await _db.Employers.FirstOrDefaultAsync(e => e.Id == vm.EmployerId);
                _db.Jobs.Add(new Job
                {
                    Start = vm.Start ?? DateTime.Now,
                    Finish = vm.Finish ?? DateTime.Now,
                    Title = vm.Title,
                    Employer = employer,
                    Description = vm.Description,
                    Updated = DateTime.Now
                });
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            vm.Employers = _db.Employers.Select(e => new SelectListItem
            {
                Text = e.Name,
                Value = e.Id.ToString()
            });
            return View(vm);
        }

        // GET: Jobs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = await _db.Jobs.FindAsync(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Start,Finish,Title,Employer,Description")] Job job)
        {
            job.Updated = DateTime.Now;
            if (ModelState.IsValid)
            {
                _db.Entry(job).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(job);
        }

        // GET: Jobs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = await _db.Jobs.FindAsync(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Job job = await _db.Jobs.FindAsync(id);
            _db.Jobs.Remove(job);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
