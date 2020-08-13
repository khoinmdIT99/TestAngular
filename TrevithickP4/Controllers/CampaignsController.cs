using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrevithickP4.Data;
using TrevithickP4.Models;

namespace TrevithickP4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        
      

        public CampaignsController(ApplicationDbContext context)
        {
            _context = context;
        }

        //// GET: api/Campaigns
        //[HttpGet]
        //public IEnumerable<Campaign> Getcampaigns()
        //{
        //    return _context.campaigns;
        //}

        // GET: api/Campaigns
        [HttpGet]
        public IEnumerable <Campaign> Getcampaigns(int page = 1, int per_page = 10)
        {
            if (page == -1 && per_page == 0) {
                return _context.campaigns;
            }
            else { 
                return (from campaign in _context.campaigns
                        orderby campaign.Vendor ascending
                        select campaign)
                       .Skip(page * per_page).Take(per_page);
            }
            
        }

        // GET: api/Campaigns/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCampaign([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var campaign = await _context.campaigns.FindAsync(id);

            if (campaign == null)
            {
                return NotFound();
            }

            return Ok(campaign);
        }

        // PUT: api/Campaigns/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCampaign([FromRoute] int id, [FromBody] Campaign campaign)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != campaign.Id)
            {
                return BadRequest();
            }

            _context.Entry(campaign).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CampaignExists(id))
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

        // POST: api/Campaigns
        [HttpPost]
        public async Task<IActionResult> PostCampaign([FromBody] Campaign campaign)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.campaigns.Add(campaign);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCampaign", new { id = campaign.Id }, campaign);
        }

        // DELETE: api/Campaigns/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCampaign([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var campaign = await _context.campaigns.FindAsync(id);
            if (campaign == null)
            {
                return NotFound();
            }

            _context.campaigns.Remove(campaign);
            await _context.SaveChangesAsync();

            return Ok(campaign);
        }

        private bool CampaignExists(int id)
        {
            return _context.campaigns.Any(e => e.Id == id);
        }
    }
}