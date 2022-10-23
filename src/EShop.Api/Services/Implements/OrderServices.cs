using EShop.Api.Contracts;
using EShop.Api.Entities;

namespace EShop.Api.Services.Implements
{
    public class OrderServices : IOrderServices
    {
        private readonly EShopDbContext _dbContext;

        public OrderServices(EShopDbContext eShopDbContext)
        {
            _dbContext = eShopDbContext;
        }

        public bool Add(Order order)
        {
            bool isExist = _dbContext.Orders.Any(m => m.PuchaseOrderNumber == order.PuchaseOrderNumber);
            if (isExist)
                return false;
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
            return true;
        }

        public IEnumerable<Order> Get(OrderFilter filter)
        {
            if (filter == null)
            {
                return _dbContext.Orders.ToList();
            }

            var query = _dbContext.Orders.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.PuchaseOrderNum))
            {
                query = query.Where(m => m.PuchaseOrderNumber == filter.PuchaseOrderNum);
            }

            if (!string.IsNullOrWhiteSpace(filter.BuyerName))
            {
                query = query.Where(m => m.BuyerName == filter.BuyerName);
            }

            if (!string.IsNullOrWhiteSpace(filter.BillingZipCode))
            {
                query = query.Where(m => m.BillingZipCode == filter.BillingZipCode);
            }

            return query.ToList();
        }
    }
}
