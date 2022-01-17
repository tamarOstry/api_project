using Entities;
using System.Threading.Tasks;

namespace DL
{
    public interface IordersDL
    {

        public Task<Order> createOrder(Order Order);

    }
}