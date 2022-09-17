using System;
using System.Threading.Tasks;
using checkpoint7.Models;
using checkpoint7.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace checkpoint7.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;
        private readonly RecipesService _recipesService;

        public AccountController(AccountService accountService, RecipesService recipesService)
        {
            _accountService = accountService;
            _recipesService = recipesService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<Account>> Get()
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                return Ok(_accountService.GetOrCreateProfile(userInfo));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("recipes")]
        public async Task<ActionResult<List<Recipe>>> GetAccountRecipesAsync()
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                List<Recipe> recipes = _recipesService.GetAccountRecipes(userInfo.Id);
                return recipes;
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }


}