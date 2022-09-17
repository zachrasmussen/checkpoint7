using System.Collections.Generic;
using System.Data;
using checkpoint7.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace checkpoint7.Services
{
    public class StepsRepository
    {
        private readonly IDbConnection _db;

        public StepsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal ActionResult<Step> CreateStep(Step stepData)
        {
            string sql = @"
      INSERT INTO steps
      (position, body, recipeId)
      VALUES
      (@Position, @body, @RecipeId);
      SELECT LAST_INSERT_ID();
      ";
            int id = _db.ExecuteScalar<int>(sql, stepData);
            stepData.Id = id;
            return stepData;
        }

        internal List<Step> getRecipeSteps(int recipeId)
        {
            string sql = @"
      SELECT * FROM steps WHERE recipeId = @recipeId;
      ";
            return _db.Query<Step>(sql, new { recipeId }).ToList();
        }

        internal Step GetStepById(int id)
        {
            string sql = @"
      SELECT * FROM steps WHERE id = @id;
      ";
            return _db.QueryFirstOrDefault<Step>(sql, new { id });
        }

        internal ActionResult<string> DeleteStep(int stepId)
        {
            string sql = @"
      DELETE FROM steps WHERE id = @stepId LIMIT 1
      ";
            _db.Execute(sql, new { stepId });
            return ("deleted");
        }
    }
}