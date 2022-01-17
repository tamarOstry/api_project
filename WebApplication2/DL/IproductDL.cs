using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IproductDL
    {
        public Task<List<Product>> getAllProduct();
        public Task<List<Product>> getProductByCategory(int categoryId);
    }
}