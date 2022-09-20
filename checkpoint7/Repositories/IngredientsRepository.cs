using System.Collections.Generic;
using System.Data;
using checkpoint7.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace checkpoint7.Repositories
{
    public class IngredientsRepository
    {
        private readonly IDbConnection _db;

        public IngredientsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IngredientsRepository CreateIngredient(IngredientsRepository ingredientData)
        {
            string sql = @"
            INSERT INTO ingredients
            (name, quantity, recipeId)
            VALUES
            (@Name, @Quantity, @RecipeId);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, ingredientData);
            ingredientData.CreateIngredient = id;
            return ingredientData;
        }

        internal Ingredient GetIngredientById(int id)
        {
            string sql = @"
            SELECT * FROM ingredients WHERE id = @id
            ";
            return _db.Query<Ingredient>(sql, new { id }).FirstOrDefault();
        }

        internal ActionResult<string> DeleteIngredient(int ingredientId)
        {
            string sql = @"
            DELETE * FROM ingredients WHERE id = @ingredientId LIMIT 1
            ";
            _db.Execute(sql, new { ingredientId });
            return ("deleted");
        }

        internal List<Ingredient> GetRecipeIngredients(int id)
        {
            string sql = @"
            SELECT * FROM ingredients WHERE recipeId = @id
            ";
            return _db.Query<Ingredient>(sql, new { id }).ToList();
        }
    }
}