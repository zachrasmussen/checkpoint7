using System;
using System.Collections.Generic;
using checkpoint7.Models;
using Microsoft.AspNetCore.Mvc;

namespace checkpoint7.Services
{
    public class StepsService
    {
        private readonly RecipesService _recipesService;
        private readonly StepsRepository _stepsRepo;
        public StepsService(RecipesService recipesService, StepsRepository stepsRepo)
        {
            _recipesService = recipesService;
            _stepsRepo = stepsRepo;
        }

        internal ActionResult<Step> CreateStep(Step stepData, string userId)
        {
            Recipe targetRecipe = _recipesService.GetById(stepData.RecipeId);
            if (targetRecipe.CreatorId != userId)
            {
                throw new System.Exception("Sorry, you can't add a step to someone else's recipe");
            }
            return _stepsRepo.CreateStep(stepData);
        }

        internal List<Step> GetRecipeSteps(int recipeId)
        {
            return _stepsRepo.getRecipeSteps(recipeId);
        }
        internal ActionResult<Step> GetStepById(int id)
        {
            Step step = _stepsRepo.GetStepById(id);
            if (step == null)
            {
                throw new Exception("This is an invalid step Id");
            }
            return step;
        }



        internal ActionResult<string> DeleteStep(int stepId, string userId)
        {
            Step targetStep = _stepsRepo.GetStepById(stepId);
            Recipe targetRecipe = _recipesService.GetById(targetStep.RecipeId);
            if (userId != targetRecipe.CreatorId)
            {
                throw new Exception("Cannot delete steps on someone else's recipe");
            }
            return _stepsRepo.DeleteStep(stepId);
        }
    }
}
