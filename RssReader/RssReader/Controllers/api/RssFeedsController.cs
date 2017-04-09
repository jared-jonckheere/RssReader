using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RssReaderModel.RssFeed;

namespace RssReader.Controllers.api
{
    [Produces("application/json")]
    [Route("api/RssFeeds")]
    public class RssFeedsController : Controller
    {
        private readonly RssFeedContext _context;

        public RssFeedsController(RssFeedContext context)
        {
            _context = context;
        }

        // GET: api/RssFeeds
        [HttpGet]
        public IEnumerable<RssFeed> GetFeeds()
        {
            return _context.Feeds;
        }

        // GET: api/RssFeeds/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRssFeed([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rssFeed = await _context.Feeds.SingleOrDefaultAsync(m => m.Id == id);

            if (rssFeed == null)
            {
                return NotFound();
            }

            return Ok(rssFeed);
        }

        // PUT: api/RssFeeds/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRssFeed([FromRoute] int id, [FromBody] RssFeed rssFeed)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rssFeed.Id)
            {
                return BadRequest();
            }

            _context.Entry(rssFeed).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RssFeedExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/RssFeeds
        [HttpPost]
        public async Task<IActionResult> PostRssFeed([FromBody] RssFeed rssFeed)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Feeds.Add(rssFeed);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRssFeed", new { id = rssFeed.Id }, rssFeed);
        }

        // DELETE: api/RssFeeds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRssFeed([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rssFeed = await _context.Feeds.SingleOrDefaultAsync(m => m.Id == id);
            if (rssFeed == null)
            {
                return NotFound();
            }

            _context.Feeds.Remove(rssFeed);
            await _context.SaveChangesAsync();

            return Ok(rssFeed);
        }

        private bool RssFeedExists(int id)
        {
            return _context.Feeds.Any(e => e.Id == id);
        }
    }
}