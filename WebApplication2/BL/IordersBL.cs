using Entities;
using System.Threading.Tasks;

namespace BL
{
    public interface IordersBL
    {
        public Task<Order> createOrder(Order Order);
    }
}