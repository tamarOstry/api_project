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
    public class ordersController : ControllerBase
    {

        IordersBL IordersBL;
        IMapper _Mapper;
        public ordersController(IordersBL IordersBL, IMapper mapper)
        {
            this.IordersBL = IordersBL;
            _Mapper = mapper;
        }

        // GET: api/<ordersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ordersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ordersController>
        [HttpPost]
        public async Task<ActionResult<order_DTO>> Post([FromBody] order_DTO order)
        {
            Order Orders =await  IordersBL.createOrder(_Mapper.Map <Order> (order));
            if (Orders == null)
                return NoContent();
            return _Mapper.Map<order_DTO>(Orders);
        }

        // PUT api/<ordersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ordersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
