using System;
using System.Collections.Generic;
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

        [HttpGet]
        public ActionResult<List<Step>> GetAll()
        {
            try
            {
                List<Step> steps = _stepsService.GetAll();
                return Ok(steps);
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
        }
    }
}