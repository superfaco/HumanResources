using HumanResources.Server.Contexts;
using HumanResources.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResources.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenderController : ControllerBase
    {
        private readonly HumanResourcesContext context;

        public GenderController(HumanResourcesContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await context.Gender.ToListAsync());
            }
            catch (Exception)
            {
                return Problem();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                return Ok(await context.Gender.FirstOrDefaultAsync(gender => gender.Id == id));
            }
            catch (Exception)
            {
                return Problem();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Gender gender)
        {
            try
            {
                await context.AddAsync(gender);
                await context.SaveChangesAsync();
                return Ok(gender);
            }
            catch (Exception)
            {
                return Problem();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(Gender gender)
        {
            try
            {
                context.Entry(gender).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(gender);
            }
            catch (Exception)
            {
                return Problem();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                Gender g = await context.Gender.FirstOrDefaultAsync(gender => gender.Id == id);
                context.Remove(g);
                await context.SaveChangesAsync();
                return Ok(g);
            }
            catch (Exception)
            {
                return Problem();
            }
        }
    }
}
