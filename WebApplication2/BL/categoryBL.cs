using DL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class categoryBL : IcategoryBL
    {
        IcategoryDL IcategoryDL;
        public categoryBL(IcategoryDL IcategoryDL)
        {
            this.IcategoryDL = IcategoryDL;
        }

        public async Task<List<Category>> getAllCategory()
        {
            var categories =await  IcategoryDL.getAllCategory();
            if (categories == null)
                return null;
            return categories;
        }

    }
}
