using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TradingPlatform.Data
{
    [Table("stock")]
    public class Stock
    {
        [Key, Required]
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
    }
}
