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
    public class productsController : ControllerBase
    {
        IproductBL IproductBL;
        IMapper _Mapper;
        public productsController(IproductBL IproductBL, IMapper mapper)
        {
            this.IproductBL = IproductBL;
            _Mapper = mapper;
        }

        // GET: api/<productsController>
        [HttpGet]
        public async Task<ActionResult<List<product_DTO>>> Get()
        {
            List<Product> products= await IproductBL.getAllProduct();
            if (products == null)
                return NoContent();
            return _Mapper.Map<List<product_DTO>>(products);
        }

        // GET api/<productsController>/5
        [HttpGet("{categoryId}")]
        public async Task<ActionResult<List<product_DTO>>> Get(int categoryId)
        {
          var products = await IproductBL.getProductByCategory(categoryId);
            if (products == null)
                return NoContent();
            return _Mapper.Map<List<product_DTO>>(products);
        }

        // POST api/<productsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<productsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<productsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
