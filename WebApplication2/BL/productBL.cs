using DL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class productBL : IproductBL
    {
        IproductDL IproductDL;
        public productBL(IproductDL IproductDL)
        {
            this.IproductDL = IproductDL;
        }

        public Task<List<Product>> getAllProduct()
        {
            var products = IproductDL.getAllProduct();
            if(products==null)
               return null;
            return products;
        }

        public async Task<List<Product>> getProductByCategory(int categoryId)
        {
            var products = await IproductDL.getProductByCategory(categoryId);
            if (products == null)
                return null;
            return products;
        }
        
    }
}
