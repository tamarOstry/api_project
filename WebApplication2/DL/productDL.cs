using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class productDL : IproductDL
    {
        vaichleContext vaichleContext;

        public productDL(vaichleContext vaichleContext)
        {
            this.vaichleContext = vaichleContext;
        }

        public async Task<List<Product>> getAllProduct()
        {
            var productsToGet = await vaichleContext.Products.ToListAsync(); 
            if (productsToGet == null)
                return null;
            return productsToGet;
        }

        public async Task<List<Product>> getProductByCategory(int categoryId)
        {
            var productsToGet = await vaichleContext.Products.Where(p=>p.CategoryId== categoryId).ToListAsync();
            if (productsToGet == null)
                return null;
            return productsToGet;
        }
        
    }
}
