using EShop.Api.Contracts;
using EShop.Api.Entities;

namespace EShop.Api.Services.Implements
{
    public class OrderServices : IOrderServices
    {
        public bool Add(Order order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));
            if (order.BuyerName == null) throw new ArgumentNullException(nameof(order.BuyerName));
            if (order.PuchaseOrderNumber == null) throw new ArgumentNullException(nameof(order.PuchaseOrderNumber));
            if (order.OrderAmount <= 0) throw new ArgumentOutOfRangeException(nameof(order.OrderAmount));
            if (order.BillingZipCode == null) throw new ArgumentNullException(nameof(order.BillingZipCode));

            using var db = new EShopDbContext();

            bool isExist = db.Orders.Any(m => m.PuchaseOrderNumber == order.PuchaseOrderNumber);
            if (isExist)
                return false;
            db.Orders.Add(order);
            db.SaveChanges();
            return true;
        }

        public IEnumerable<Order> Get(OrderFilter filter)
        {
            using var db = new EShopDbContext();
            if (filter == null)
            {
                return db.Orders.ToList();
            }

            var query = db.Orders.AsQueryable();

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
