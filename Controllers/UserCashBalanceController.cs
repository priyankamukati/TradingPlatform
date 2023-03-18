using Microsoft.AspNetCore.Mvc;
using TradingPlatform.Data;
using TradingPlatform.Model;

namespace TradingPlatform.Controllers
{
    [ApiController]
    public class UserCashBalanceController : ControllerBase
    {
        private readonly DbHelper _db;
        public UserCashBalanceController(DataContext dataContext)
        {
            _db = new DbHelper(dataContext);
        }


        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                UserInfoModel data = _db.GetUserCashBalanceById(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult Post([FromBody] UpdateCashBalanceRequest model)
        {
            try
            {
                _db.SaveUserCashBalance(model);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
