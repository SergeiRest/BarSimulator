using Data;
using Recipes;
using UnityEngine;
using Zenject;

namespace Guests
{
    public class BaseGuestTemplate : AbstractGuestTemplate
    {
        [Inject] private RecipeGenerator _recipeGenerator;

        private Recipe _selectedRecipe;

        protected override void Init()
        {
            _selectedRecipe = _recipeGenerator.GetRandom();

            Debug.Log($"Make me {_selectedRecipe.Name}");
        }
    }
}