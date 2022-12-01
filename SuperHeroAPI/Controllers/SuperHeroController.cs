using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SuperHeroAPI.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class SuperHeroController : ControllerBase
{
    private readonly DataContext _dataContext;

    public SuperHeroController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    [HttpGet]
    public async Task<ActionResult<SuperHero>> Get()
    {
        return Ok(await _dataContext.SuperHeroes.ToListAsync());
    }

    [HttpPost]
    public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
    {
        _dataContext.SuperHeroes.Add(hero);
        await _dataContext.SaveChangesAsync();
        return Ok(await _dataContext.SuperHeroes.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SuperHero>> Get(int id)
    {
        var superHero = await _dataContext.SuperHeroes.FindAsync(id);
        if (superHero == null)
        {
            return BadRequest("No such hero");
        }
        return Ok(superHero);
    }

    [HttpPut]
    public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request)
    {
        var superHero = await _dataContext.SuperHeroes.FindAsync(request.Id);
        if (superHero == null)
        {
            return BadRequest("No such hero");
        }

        superHero.Name = request.Name;
        superHero.Place = request.Place;
        superHero.FirstName = request.FirstName;
        superHero.LastName = request.LastName;
        await _dataContext.SaveChangesAsync();
        return Ok(await _dataContext.SuperHeroes.ToListAsync());
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<List<SuperHero>>> Delete(int id)
    {
        var superHero = await _dataContext.SuperHeroes.FindAsync(id);
        if (superHero == null)
        {
            return BadRequest("No such hero");
        }

        _dataContext.Remove(superHero);
        await _dataContext.SaveChangesAsync();
        return Ok(await _dataContext.SuperHeroes.ToListAsync());
    }
}