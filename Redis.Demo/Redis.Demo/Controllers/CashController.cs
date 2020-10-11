using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Redis.Demo.Services;

namespace Redis.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashController : ControllerBase
    {
        private ICachService _cachService;

        public CashController(ICachService cachService)
        {
            _cachService = cachService;
        }
        [HttpGet("cashe/{key}")]
        public async Task<IActionResult> Get([FromRoute]string key)
        {
            var value = await _cachService.GetCacheValueAsync(key);
            return string.IsNullOrEmpty(value) ?(IActionResult)NotFound() : Ok(value);
        }

        [HttpPost("cache")]
        public async Task<IActionResult> SetCacheValue([FromBody] KeyValuePair<string,string> keyValue)
        {
            await _cachService.SetCacheValueAsync(keyValue.Key, keyValue.Value);
            return Ok();
        }

    }
}