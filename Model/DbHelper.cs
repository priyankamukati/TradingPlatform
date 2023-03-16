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
               
                ticker = row.ticker,
                initial_price = row.initial_price,
                company_name = row.company_name,
                volume =  row.volume,
                current_price = row.current_price,
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
                ticker = row.ticker,
                initial_price = row.initial_price,
                company_name = row.company_name,
                volume =  row.volume,
                current_price = row.current_price,
            }; 
        }

        public void SaveStock(StockModel stockModel)
        {
            Stock dbStock = new Stock();
            dbStock.id = stockModel.id;
            dbStock.ticker = stockModel.ticker;
            dbStock.initial_price = stockModel.initial_price;
            dbStock.company_name  = stockModel.company_name ;
            dbStock.volume = stockModel.volume;
            dbStock.current_price = stockModel.current_price;
           
            //_context.Database.Log = Console.Write;
            _context.Stocks.Add(dbStock);
            _context.SaveChanges();
        }
        public List<UserInfoModel> GetUserInfo()
        {
            List<UserInfoModel> response = new List<UserInfoModel>();
            var dataList = _context.User_Infos.ToList();
            dataList.ForEach(row => response.Add(new UserInfoModel()
            {
                id = row.id,               
                full_name = row.full_name,
                username = row.username,
                email = row.email,
                type =  row.type,
                create_date =  row.create_date,
                update_date =  row.update_date,
                cash_balance = row.cash_balance
            }));
            return response;
        }

        public UserInfoModel GetUserInfoById(int id)
        {
            var row = _context.User_Infos.Where(d=>d.id.Equals(id)).FirstOrDefault();

            if(row == null) {
                return new UserInfoModel();
            }

            return new UserInfoModel() {
                id = row.id,               
                full_name = row.full_name,
                username = row.username,
                email = row.email,
                type =  row.type,
                create_date =  row.create_date,
                update_date =  row.update_date,
                cash_balance = row.cash_balance
            }; 
        }

        public void SaveUserInfo(UserInfoModel userInfoModel)
        {
            user_info dbUserInfo = new user_info();
            dbUserInfo.id = userInfoModel.id;
            dbUserInfo.full_name = userInfoModel.full_name;
            dbUserInfo.username = userInfoModel.username;
            dbUserInfo.email  = userInfoModel.email ;
            dbUserInfo.type = userInfoModel.type;
            dbUserInfo.cash_balance = 500;            
            _context.User_Infos.Add(dbUserInfo);
            _context.SaveChanges();
        }

        public List<UserStockModel> GetUserStockById(int id)
        {
           List<UserStockModel> response = new List<UserStockModel>();
        {

            var dataList = (from us in _context.User_Stocks
                  join s in _context.Stocks
                  on us.stock_id equals s.id
                  where us.user_id == id
                  select new { 
                ticker = s.ticker,
                quantity = us.quantity,
                stock_id = us.stock_id,
                current_price =  s.current_price

                  }).ToList();

            dataList.ForEach(row => response.Add(new UserStockModel()
            {
             
                ticker = row.ticker,
                quantity = row.quantity,
                stock_id = row.stock_id,
                current_price =  row.current_price,
                current_amount= row.quantity*row.current_price

            }));

             return response;
        
            }

        }
        public UserOrderModel GetUserOrderById(int id)
        {
            var row = _context.User_Orders.Where(d=>d.user_id.Equals(id)).FirstOrDefault();

            if(row == null) {
                return new UserOrderModel();
            }

            return new UserOrderModel() {
                user_id = row.user_id,
                stock_id = row.stock_id,               
                quantity = row.quantity,
                order_nature = row.order_nature,
                order_type = row.order_type,
                limit_price =  row.limit_price

            };
            
        }
    
        public void SaveUserOrder(UserOrderModel userOrderModel)
        {
            user_order dbUserOrder = new user_order();
            dbUserOrder.user_id = userOrderModel.user_id;
            dbUserOrder.stock_id = userOrderModel.stock_id;
            dbUserOrder.quantity = userOrderModel.quantity;
            dbUserOrder.order_nature = userOrderModel.order_nature;
            dbUserOrder.order_type  = userOrderModel.order_type ;
            dbUserOrder.limit_price = userOrderModel.limit_price;
            dbUserOrder.limit_expiration = 7;
        
            _context.User_Orders.Add(dbUserOrder);
            _context.SaveChanges();
        }
        }
    }
 
    


  
