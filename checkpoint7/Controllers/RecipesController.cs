
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace checkpoint7.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly RecipesService _recipesService;
        public RecipesController(RecipesService recipesService)
        {
            _recipesService = recipesService;
        }

        [HttpGet]
        public ActionResult<List<RecipesController>> GetAll()
        {
            try
            {

            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
        }
    }
}
