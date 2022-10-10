using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZaFirmu.Data;

namespace ZaFirmu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Student : Controller
    {
        private readonly MojContext _context;

        public Student(MojContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> Get()
        {
            return Ok(await _context.Student.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> Get(int id)
        {
            var hero = await _context.Student.FindAsync(id);
            if (hero == null)
                return BadRequest("Student not found.");
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<Student>>> AddHero(Student hero)
        {
            _context.Student.Add(hero);
            await _context.SaveChangesAsync();

            return Ok(await _context.Student.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Student>>> UpdateHero(Student request)
        {
            var dbHero = await _context.Student.FindAsync(request.StudentId);
            if (dbHero == null)
                return BadRequest("Student not found.");

            
            dbHero.brIndeksa = request.brIndeksa;
            dbHero.Ime = request.Ime;
            dbHero.Prezime = request.Prezime;
            dbHero.Godina = request.Godina;
            dbHero.IDStudenta = request.IDStatusa;

            await _context.SaveChangesAsync();

            return Ok(await _context.Student.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Student>>> Delete(int id)
        {
            var dbHero = await _context.Student.FindAsync(id);
            if (dbHero == null)
                return BadRequest("Student not found.");

            _context.Student.Remove(dbHero);
            await _context.SaveChangesAsync();

            return Ok(await _context.Student.ToListAsync());
        }

    }
}

