using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameWorkCore;
using ZaFirmu.Data;

namespace ZaFirmu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Status : Controller
    {
        private readonly MojContext _context;

        public Status(MojContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Statuscs>>> Get()
        {
            return Ok(await _context.Statuscs.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Statuscs>> Get(int id)
        {
            var hero = await _context.Statuscs.FindAsync(id);
            if (hero == null)
                return BadRequest("Student not found.");
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<Student>>> AddHero(Statuscs hero)
        {
            _context.Statuscs.Add(hero);
            await _context.SaveChangesAsync();

            return Ok(await _context.Statuscs.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Statuscs>>> UpdateHero(Statuscs request)
        {
            var dbHero = await _context.Student.FindAsync(request.StutusStudenta);
            if (dbHero == null)
                return BadRequest("Status not found.");


            dbHero.NazivStatusa = request.NazivStatusa;
            
            await _context.SaveChangesAsync();

            return Ok(await _context.Statuscs.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Statuscs>>> Delete(int id)
        {
            var dbHero = await _context.Statuscs.FindAsync(id);
            if (dbHero == null)
                return BadRequest("Student not found.");

            _context.Statuscs.Remove(dbHero);
            await _context.SaveChangesAsync();

            return Ok(await _context.Statuscs.ToListAsync());
        }

    }
}