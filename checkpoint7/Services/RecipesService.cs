using System;
using System.Collections.Generic;
using checkpoint7.Controllers;
using checkpoint7.Models;
using Microsoft.AspNetCore.Mvc;

namespace checkpoint7.Services
{
    public class RecipesService
    {
        private readonly RecipesRepository _recipesRepo;

        public string CreatorId { get; internal set; }

        public RecipesService(RecipesRepository recipesService)
        {
            _recipesRepo = recipesService;
        }
        internal Recipe CreateRecipe(RecipesService recipeData)
        {
            return _recipesRepo.CreateRecipe(recipeData);
        }

        internal List<Recipe> GetAll()
        {
            return _recipesRepo.GetAll();
        }

        internal Recipe GetById(int id)
        {
            Recipe target = _recipesRepo.GetById(id);
            if (target == null)
            {
                throw new Exception("invalid recipe id");
            }
            return target;
        }

        internal RecipesService GetById(object recipeId)
        {
            throw new NotImplementedException();
        }

        internal ActionResult<Recipe> UpdateRecipe(int recipeId, Recipe recipeData)
        {
            Recipe target = GetById(recipeId);
            if (target.CreatorId != recipeData.CreatorId)
            {
                throw new Exception("You're not authorized");
            }
            target.Picture = recipeData.Picture ?? target.Picture;
            target.Title = recipeData.Title ?? target.Title;
            target.Subtitle = recipeData.Subtitle ?? target.Subtitle;
            target.Category = recipeData.Category ?? target.Category;

            return _recipesRepo.UpdateRecipe(target);
        }

        internal ActionResult<string> DeleteRecipe(int id, string userId)
        {
            Recipe original = GetById(id);
            if (original.CreatorId != userId)
            {
                throw new Exception("You're not authorized");
            }
            return _recipesRepo.DeleteRecipe(id);
        }

        internal List<Recipe> GetAccountRecipes(string userId)
        {
            List<Recipe> recipes = _recipesRepo.GetAccountRecipes(userId);
            return recipes;
        }

        internal Recipe CreateRecipe(RecipesController recipeData)
        {
            throw new NotImplementedException();
        }

        internal Task<ActionResult<Recipe>> UpdateRecipe(int id, RecipesController recipeData)
        {
            throw new NotImplementedException();
        }
    }


}