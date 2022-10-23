namespace EShop.Api.Contracts
{
    public class OrderFilter
    {
        public string PuchaseOrderNum { get; set; } = string.Empty;
        public string BuyerName { get; set; } = string.Empty;
        public string BillingZipCode { get; set; } = string.Empty;
    }
}
