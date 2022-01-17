
using DL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ordersBL : IordersBL
    {
        IordersDL IordersDL;
        public ordersBL(IordersDL IordersDL)
        {
            this.IordersDL = IordersDL;
        }

        public async Task<Order> createOrder(Order Order)
        {
            var Order1 = await IordersDL.createOrder(Order);
            if (Order1 == null)
                return null;
            return Order1;
        }

    }
}
