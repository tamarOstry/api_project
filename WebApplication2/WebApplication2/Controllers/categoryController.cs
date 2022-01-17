using AutoMapper;
using BL;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class categoryController : ControllerBase
    {
        IcategoryBL IcategoryBL;
        IMapper _Mapper;
        public categoryController(IcategoryBL IcategoryBL, IMapper mapper)
        {
            this.IcategoryBL = IcategoryBL;
            _Mapper = mapper;
        }

        // GET: api/<categoryController>
        [HttpGet]
        public async Task<ActionResult<List<category_DTO>>> Get()
        {
            List<Category> categories = await IcategoryBL.getAllCategory();
            if (categories == null)
                return NoContent();
            return _Mapper.Map<List<category_DTO>>(categories);
        }

        // GET api/<categoryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<categoryController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<categoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<categoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
