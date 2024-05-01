using System.Linq;
using Data;
using UnityEngine;
using Zenject;

namespace Recipes
{
    public class RecipeGenerator
    {
        [Inject] private RecipeData _recipeData;
        
        public Recipe GetRandom()
        {
            int random = Random.Range(0, _recipeData.Recipes.Length);

            return _recipeData.Recipes[random];
        }

        public Recipe GetByName(string name)
        {
            return _recipeData.Recipes.First(recipe => recipe.Name == name);
        }
    }
}