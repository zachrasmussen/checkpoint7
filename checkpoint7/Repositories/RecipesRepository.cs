namespace checkpoint7.Repositories
{
    public class RecipesRepository
    {
        private readonly IDbConnection _db;

        public RecipesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal RecipesRepository CreateRecipe(RecipesRepository recipeData)
        {
            string sql = @"
            INSERT INTO recipes
            (@Picture, @Title, @Subtitle, @Category, @creatorId);
            SELECT LAST_INSERT_ID();  
            ";
            int id = _db.ExecuteScalar<int>(sql, recipeData);
            recipeData.Id = id;
            return recipeData;
        }

        internal RecipesRepository GetById(int id)
        {
            string sql = @"
            SELECT
            r.*,
            a.*
            FROM recipes r
            JOIN accounts a ON r.creatorId = a.id
            WHERE r.id = @id
            ";
            return _db.Query<RecipesRepository, Account, Recipe>(sql, (recipe, account) =>
            {
                recipe.Creator = account;
                return recipe;
            }, new { id }).FirstOrDefault();
        }

        internal List<Recipe> GetAll()
        {
            string sql = @"
            SELECT
            r.*
            a.*
            FROM recipes r
            JOIN accounts a ON r.creatorId = a.id;
            ";
            return _db.Query<RecipesRepository, Account, Recipe>(sql, (RecipesRepository, account) =>
            {
                recipe.Creator = account;
                return recipe;
            }).ToList();
        }

        internal ActionResult<string> DeleteRecipe(int id)
        {
            string sql = @"
            DELETE FROM recipes WHERE id = @id LIMIT 1
            ";
            _db.Execute(sql, new { id });
            string res = "deleted";
            return res;
        }

        internal List<Recipe> GetAccountRecipes(string UserId)
        {
            string sql = @"
            SELECT * FROM recipes WHERE creatorId = @UserId
            ";
            List<Recipe> recipes = _db.Query<Recipe>(sql, new { UserId }).ToList;
            return recipes;
        }

        internal RecipesRepository UpdateRecipe(Recipe RecipeData)
        {
            string sql = @"
            UPDATE recipes
            SET
            picture = @Picture,
            title = @Title,
            subtitle = @Subtitle,
            category = @Category
            WHERE id = @Id
            ";
            _db.Execute(sql, RecipeData);
            return RecipeData;
        }
    }
}