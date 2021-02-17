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
        public object Get()
        {
            return context.Gender;
        }

        [HttpGet("{id}")]
        public object Get(long id)
        {
            return context.Gender.First(gender => gender.Id == id);
        }

        [HttpPost]
        public object Post(Gender gender)
        {
            context.Add(gender);
            context.SaveChanges();
            return gender;
        }

        [HttpPut]
        public object Put(Gender gender)
        {
            context.Entry(gender).State = EntityState.Modified;
            context.SaveChanges();
            return gender;
        }

        [HttpDelete("{id}")]
        public object Delete(long id)
        {
            Gender g = context.Gender.First(gender => gender.Id == id);
            context.Remove(g);
            context.SaveChanges();
            return g;
        }
    }
}
