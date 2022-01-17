using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IcategoryDL
    {
        public Task<List<Category>> getAllCategory();
    }
}