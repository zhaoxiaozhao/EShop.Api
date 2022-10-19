using EShop.Api.Contracts;
using EShop.Api.Entities;

namespace EShop.Api.Services
{
    public interface IOrderServices
    {
        public IEnumerable<Order> Get(OrderFilter filter);
        public bool Add(Order order);
    }
}
