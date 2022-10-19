using System.ComponentModel.DataAnnotations;

namespace EShop.Api.Entities
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public string PuchaseOrderNumber { get; set; }
        [Required]
        public string BuyerName { get; set; }
        [Required]
        public string BillingZipCode { get; set; }
        [Required]
        public decimal OrderAmount { get; set; }

    }
}
