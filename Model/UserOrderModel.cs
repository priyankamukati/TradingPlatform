namespace TradingPlatform.Model
{
    public class UserOrderModel
    {
        public int user_id { get; set; }
        public int stock_id { get; set; }
        public int quantity { get; set; }
         public string order_nature { get; set; } = string.Empty;

        public string order_type { get; set; } = string.Empty;
        public double limit_price { get; set; }


    }
}


