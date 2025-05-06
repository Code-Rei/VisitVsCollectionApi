using ClientAPI.DB;
using ClientAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClientAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitWiseController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UnitWiseController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnitWise>>> GetAll()
        {
            return await _context.UnitWise.ToListAsync();
        }

        [HttpGet("summary")]
        public async Task<ActionResult> GetSummary(string bh, string funder, string state, string unit)
        {
            var visited = await _context.odNPA.CountAsync(o => o.BH == bh && o.Funder == funder && o.State == state && o.UnitName == unit);
            var reduced = await _context.odNPA.CountAsync(o => o.BH == bh && o.Funder == funder && o.State == state && o.UnitName == unit && o.isReduction);
            var collected = await _context.odNPA.CountAsync(o => o.BH == bh && o.Funder == funder && o.State == state && o.UnitName == unit && o.iscollection);
            var amount = await _context.odNPA.Where(o => o.BH == bh && o.Funder == funder && o.State == state && o.UnitName == unit)
                                             .SumAsync(o => o.Collection_Amount);

            return Ok(new
            {
                Visited = visited,
                Reduced = reduced,
                Collected = collected,
                CollectedAmount = amount
            });
        }
    }
}