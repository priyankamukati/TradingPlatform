﻿namespace TradingPlatform.Model
{
    public class StockModel
    {
        public int id { get; set; }
        public string ticker { get; set; } = string.Empty;
        public double initial_price  { get; set; }
        public string company_name { get; set; } = string.Empty;
        public int volume { get; set; }
        public double current_price { get; set; }
    }
}
