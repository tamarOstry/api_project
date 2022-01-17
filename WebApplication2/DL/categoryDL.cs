using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class categoryDL : IcategoryDL
    {
        vaichleContext vaichleContext;

        public categoryDL(vaichleContext vaichleContext)
        {
            this.vaichleContext = vaichleContext;
        }

        public async Task<List<Category>> getAllCategory()
        {
            var categoryToGet = await vaichleContext.Categories.ToListAsync();
            if (categoryToGet == null)
                return null;
            return categoryToGet;
        }
    }
}
