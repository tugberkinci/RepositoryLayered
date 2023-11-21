using Microsoft.AspNetCore.Mvc;
using Template.Api.Models;
using Template.Data.Services.Abstract;

namespace Template.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        public UserController(IUserService userService) => _userService = userService;


        /// <summary>
        /// Get all data 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _userService.GetAllAsync();
            if(!data.IsSuccess)
            {
                return BadRequest(BaseResponse<object>.Failed(data.Message));
            }

            return Ok(BaseResponse<IEnumerable<object>>.Succeed(data.Data));
        }
    }
}
