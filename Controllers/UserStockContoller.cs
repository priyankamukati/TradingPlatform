using Microsoft.AspNetCore.Mvc;
using TradingPlatform.Data;
using TradingPlatform.Model;

namespace TradingPlatform.Controllers
{
    [ApiController]
    public class UserStockController : ControllerBase
    {
        private readonly DbHelper _db;
        public UserStockController(DataContext dataContext)
        {
            _db = new DbHelper(dataContext);
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                List<UserStockModel> data = _db.GetUserStockById(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        }
    }

