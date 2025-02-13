using CreditCard.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CreditCard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmokeController : ControllerBase
    {

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok("is running!!!");
        }
    }
}
