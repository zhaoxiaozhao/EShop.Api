using System.ComponentModel.DataAnnotations;

namespace EShop.Api.Entities
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string PuchaseOrderNumber { get; set; } = string.Empty;

        [Required]
        [MaxLength(10)]
        public string BuyerName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string BillingZipCode { get; set; } = string.Empty;
        [Required]
        public decimal OrderAmount { get; set; }

    }
}
