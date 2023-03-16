using Microsoft.AspNetCore.Mvc;
using TradingPlatform.Data;
using TradingPlatform.Model;

namespace TradingPlatform.Controllers
{
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly DbHelper _db;
        public UserInfoController(DataContext dataContext)
        {
            _db = new DbHelper(dataContext);
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<UserInfoModel> data = _db.GetUserInfo();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                UserInfoModel data = _db.GetUserInfoById(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult Post([FromBody] UserInfoModel model)
        {
            try
            {
                if (model.email.Contains("@sunshine"))
                {
                    model.type = "admin";
                }
                else
                {
                    model.type = "user";
                }
                
                _db.SaveUserInfo(model);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
