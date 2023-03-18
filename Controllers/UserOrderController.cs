using Microsoft.AspNetCore.Mvc;
using TradingPlatform.Data;
using TradingPlatform.Model;

namespace TradingPlatform.Controllers
{
    [ApiController]
    public class UserOrderController : ControllerBase
    {
        private readonly DbHelper _db;
        public UserOrderController(DataContext dataContext)
        {
            _db = new DbHelper(dataContext);
        }


        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                List<UserOrderModel> data = _db.GetUserOrderById(id);
                return Ok(data);
            }
            catch (Exception ex)
            { 
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult Post([FromBody] UserOrderModel model)
        {
            try
            {
                _db.SaveUserOrder(model);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
