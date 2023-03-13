using System;
using TradingPlatform.Data;

namespace TradingPlatform.Model
{
    public class DbHelper
    {
        private DataContext _context;
        public DbHelper(DataContext context)
        {
            _context = context;
        }

        public List<StockModel> GetStocks()
        {
            List<StockModel> response = new List<StockModel>();
            var dataList = _context.Stocks.ToList();
            dataList.ForEach(row => response.Add(new StockModel()
            {
                id = row.id,
                name = row.name
            }));
            return response;
        }

        public StockModel GetStockById(int id)
        {
            var row = _context.Stocks.Where(d=>d.id.Equals(id)).FirstOrDefault();

            if(row == null) {
                return new StockModel();
            }

            return new StockModel() {
                id = row.id,
                name = row.name
            }; 
        }

        public void SaveStock(StockModel stockModel)
        {
            Stock dbStock = new Stock();
            dbStock.id = stockModel.id;
            dbStock.name = stockModel.name;
            
            _context.Stocks.Add(dbStock);
            _context.SaveChanges();
        }
    }
}
