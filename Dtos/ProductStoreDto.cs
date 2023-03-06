namespace MultiBackend.Dtos
{
    public class ProductStoreDto
    {
        public string? ProductName { get; set; }
        public int ProductId  { get; set; }
        public long ProductPrice { get; set; }
        public int ProductStock { get; set; }
        public int PorductScore { get; set; }
        public string? StoreName { get; set; }
        public int StoreId { get; set; }
        public string? StoreLogo { get; set; }
        public string? StoreLink { get; set; }
    }
}
