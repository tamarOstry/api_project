using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class ordersDL : IordersDL
    {
        vaichleContext vaichleContext;

        public ordersDL(vaichleContext vaichleContext)
        {
            this.vaichleContext = vaichleContext;
        }

        public async Task<Order> createOrder(Order Order)
        {
            using (var context = new vaichleContext())
            {
                await context.Orders.AddAsync(Order);
                await context.SaveChangesAsync();
            }
            return Order;
        }
    }
}
