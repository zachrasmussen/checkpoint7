using System;
using checkpoint7.Models;
using checkpoint7.Services;
using Microsoft.AspNetCore.Mvc;

namespace checkpoint7.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StepsController : ControllerBase
    {
        private readonly StepsService _stepsService;

        public StepsController(StepsService stepsService)
        {
            _stepsService = stepsService;
        }

        [HttpGet("{id}")]
        public ActionResult<Step> GetStepById(int id)
        {
            try
            {
                return _stepsService.GetStepById(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Step>> CreateStepAsync([FromBody] Step stepData)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                return _stepsService.CreateStep(stepData, userInfo.Id)
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<string>> deleteStepAsync(int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                return _stepsService.DeleteStep(id, userInfo.Id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message)
            }
        }
    }
}