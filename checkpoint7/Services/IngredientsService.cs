using System;
using checkpoint7.Models;
using Microsoft.AspNetCore.Mvc;

namespace checkpoint7.Services
{
    public class IngredientsService
    {
        private readonly IngredientsRepository _ingredientsRepo;
        private readonly RecipesService _recipesService;

        public object RecipeId { get; private set; }

        public IngredientsService(IngredientsRepository ingredientsRepository, RecipesService recipesService)
        {
            _ingredientsRepo = ingredientsRepository;
            _recipesService = recipesService;
        }

        internal IngredientsService GetIngredientById(int id)
        {
            IngredientsService target = _ingredientsRepo.GetIngredientById(id);
            if (target == null)
            {
                throw new Exception("invalid Id");
            }
            return target;
        }

        internal IngredientsService CreateIngredient(IngredientsService ingredientData, string userId)
        {
            RecipesService targetRecipe = _recipesService.GetById(ingredientData.RecipeId);
            if (targetRecipe.CreatorId != userId)
            {
                throw new SystemException("You can't add an ingredient to someone else's recipe");
            }
            return _ingredientsRepo.CreateIngredient(ingredientData);
        }

        internal ActionResult<string> DeleteIngredient(int ingredientId, string userId)
        {
            Ingredient targetIngredient = GetIngredientById(ingredientId);
            RecipesService targetRecipe = _recipesService.GetById(targetIngredient.id);
            if (targetRecipe.CreatorId != userId)
            {
                throw new SystemException("You can't delete ingredients if they don't belong to you.");
            }
            return _ingredientsRepo.DeleteIngredient(ingredientId);
        }

        internal Ingredient CreateIngredient(Ingredient ingredientData, string id)
        {
            throw new NotImplementedException();
        }

        internal List<Ingredient> GetRecipeIngredients(int id)
        {
            return _ingredientsRepo.GetRecipeIngredients(id);
        }
    }
}