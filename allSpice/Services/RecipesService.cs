using System.Collections.Generic;
using allSpice.Models;
using recipe.Repositories;

namespace recipes.Services
{
    public class RecipesService
    {
        private readonly RecipesRepository _repo;
        public RecipesService(RecipesRepository repo)
        {
            _repo = repo;
        }
        internal List<Recipe> Get()
        {
            return _repo.Get();
        }

        internal Recipe Create(Recipe newRecipe)
        {
            return _repo.Create(newRecipe);
        }
    }
}