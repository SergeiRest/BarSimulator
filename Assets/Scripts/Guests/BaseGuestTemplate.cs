using Data;
using Recipes;
using UnityEngine;
using Zenject;

namespace Guests
{
    public class BaseGuestTemplate : AbstractGuestTemplate
    {
        [Inject] private RecipeGenerator _recipeGenerator;
        

        protected override void Init()
        {
            _selectedCocktail = _recipeGenerator.GetRandom();

            Debug.Log($"Make me {_selectedCocktail.Name}");
        }
    }
}