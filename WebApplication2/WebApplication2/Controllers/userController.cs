using BL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Entities;
using AutoMapper;
using DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userController : ControllerBase
    { 
        IuserBL iuserBL;
        IMapper _Mapper;
        public userController(IuserBL iuserBL, IMapper mapper)
        {
            this.iuserBL = iuserBL;
            _Mapper = mapper;
        }

        // GET: api/<userController>
        [HttpGet ("{email}/{password}")]
        public async Task<ActionResult<user_DTO>> Get(string email, string password)
          {
            User user = await iuserBL.getUser(email, password);
            if(user==null)
               return NoContent();
            return _Mapper.Map<user_DTO>(user);
        }


        // GET api/<userController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<userController>
        [HttpPost]
        public async Task<User> Post([FromBody] User value)
        {
            await iuserBL.postUser(value);
            return value;
        }

        // PUT api/<userController>/5
        [HttpPut("{id}")]
        public async Task<User> Put([FromBody] User value,int id)
        {
            await iuserBL.putUser(value,id);
            return value;
        }

        // DELETE api/<userController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
