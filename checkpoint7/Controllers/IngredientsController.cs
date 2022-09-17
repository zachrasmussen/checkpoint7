namespace checkpoint7.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class IngredientsController : ControllerBase
    {

        private readonly IngredientsService _ingredientsService;

        public IngredientsController(IngredientsService @ingredientsService)
        {
            _ingredientsService = @ingredientsService;
        }

        [HttpGet("{id}")]
        public ActionResult<Ingredient> GetIngredientById(int id)
        {
            try
            {
                Ingredient target = _ingredientsService.GetIngredientById(id);
                return Ok(target);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Ingredient>> CreateIngredientAsync([FromBody] Ingredient ingredientData)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                Ingredient ingredient = _ingredientsService.CreateIngredient(ingredientData, userInfo.Id);
                return Ok(ingredient);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteIngredientAsync(int id)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                return Ok(_ingredientsService.DeleteIngredient(id, userInfo.Id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}