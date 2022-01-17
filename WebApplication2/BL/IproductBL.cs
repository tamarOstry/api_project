using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IproductBL
    {
        Task<List<Product>> getAllProduct();
        public Task<List<Product>> getProductByCategory(int categoryId);
    }
}