using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RssReaderModel.RssFeed;

namespace RssReader.Controllers
{
    public class RssFeedsController : Controller
    {
        private readonly RssFeedContext _context;

        public RssFeedsController(RssFeedContext context)
        {
            _context = context;    
        }

        // GET: RssFeeds
        [HttpGet]
        [Route("RssFeeds")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Feeds.ToListAsync());
        }

        // GET: RssFeeds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rssFeed = await _context.Feeds
                .SingleOrDefaultAsync(m => m.Id == id);
            if (rssFeed == null)
            {
                return NotFound();
            }

            return View(rssFeed);
        }

        // GET: RssFeeds/Create
        [HttpGet]
        [Route("RssFeeds/Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: RssFeeds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("RssFeeds/Create")]
        public async Task<IActionResult> Create([Bind("Title,Url")] RssFeed rssFeed)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rssFeed);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(rssFeed);
        }

        // GET: RssFeeds/Edit/5
        [Route("RssFeeds/Edit/:id")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rssFeed = await _context.Feeds.SingleOrDefaultAsync(m => m.Id == id);
            if (rssFeed == null)
            {
                return NotFound();
            }
            return View(rssFeed);
        }

        // POST: RssFeeds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Url")] RssFeed rssFeed)
        {
            if (id != rssFeed.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rssFeed);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RssFeedExists(rssFeed.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(rssFeed);
        }

        // GET: RssFeeds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rssFeed = await _context.Feeds
                .SingleOrDefaultAsync(m => m.Id == id);
            if (rssFeed == null)
            {
                return NotFound();
            }

            return View(rssFeed);
        }

        // POST: RssFeeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rssFeed = await _context.Feeds.SingleOrDefaultAsync(m => m.Id == id);
            _context.Feeds.Remove(rssFeed);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool RssFeedExists(int id)
        {
            return _context.Feeds.Any(e => e.Id == id);
        }
    }
}
