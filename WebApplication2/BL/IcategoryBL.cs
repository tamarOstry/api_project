using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IcategoryBL
    {
        public Task<List<Category>> getAllCategory();

    }
}