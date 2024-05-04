using System;
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
            //Resize();
            Debug.Log($"Make me {_selectedCocktail.Name}");
        }

        private void Resize()
        {
            string[] uniqueIngredients = new string[_selectedCocktail.StagesCount];

            for (int i = 0; i < uniqueIngredients.Length; i++)
            {
                uniqueIngredients[i] = _selectedCocktail.Ingridients[i];
            }

            Array.Resize(ref _selectedCocktail.Ingridients, _selectedCocktail.StagesCount * 2);

            int step = 0;
            for (int i = 1; i < _selectedCocktail.Ingridients.Length; i++)
            {
                if (i % 2 == 0)
                    step++;

                _selectedCocktail.Ingridients[i] = uniqueIngredients[step];
            }

            foreach (var ingridient in _selectedCocktail.Ingridients)
            {
                Debug.Log(ingridient);
            }
            
            Debug.Log(_selectedCocktail.StagesCount);
        }
    }
}