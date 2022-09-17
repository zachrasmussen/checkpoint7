
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace checkpoint7.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly RecipesService _recipesService;
        private readonly IngredientsService _ingredientsService;
        private readonly StepsService _stepsService;
        public RecipesController(RecipesService recipesService, IngredientsService @ingredientsService, StepsService stepsService)
        {
            _recipesService = recipesService;
            _ingredientsService = ingredientsService;
            _stepsService = stepsService;
        }

        [HttpGet]
        public ActionResult<List<Recipe>> Get()
        {
            try
            {
                List<Recipe> recipes = _recipesService.GetAll();
                return Ok(recipes);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Recipe> GetById(int id)
        {
            try
            {
                Recipe recipe = _recipesService.GetById(id);
                return recipe;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}/ingredients")]
        public ActionResult<List<Ingredient>> GetIngredients(int id)
        {
            try
            {
                Recipe targetRecipe = _recipesService.GetById(id)
                if (targetRecipe == null)
                {
                    throw new SystemException("invalid recipe Id");
                }
                GetRecipeIngredients(id);
                return Ok(ingredients);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}/steps")]
        public ActionResult<List<Step>> GetSteps(int id)
        {
            try
            {
                RecipesController targetRecipe = _recipesService.GetById(id);
                if (targetRecipe == null)
                {
                    throw new SystemException("invalid recipe Id");
                }
                List<Step> steps = _stepsService.GetRecipeSteps(id);
                return Ok(steps)
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Recipe>> CreateRecipeAsync([FromBody] RecipesController recipeData)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                recipeData.CreatorId = userInfo.Id;
                Recipe recipe = _recipesService.CreateRecipe(recipeData);
                recipe.Creator = userInfo;
                return Ok(recipe);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Recipe>> UpdateRecipeAsync(int id, [FromBody] RecipesController recipeData)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                recipeData.Id = id;
                recipeData.CreatorId = userInfo.Id;
                return _recipesService.UpdateRecipe(id, recipeData);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteRecipeAsync(int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                return _recipesService.DeleteRecipe(id, userInfo.Id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
