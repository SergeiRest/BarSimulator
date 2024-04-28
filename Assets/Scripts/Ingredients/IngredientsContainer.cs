using System.Linq;
using Data;
using Zenject;

namespace Ingredients
{
    public class IngredientsContainer
    {
        private Ingredient[] _ingredients;

        [Inject]
        private void Construct(IngredientsData _data)
        {
            _ingredients = new Ingredient[_data.Ingredients.Length];

            for (int i = 0; i < _ingredients.Length; i++)
            {
                _ingredients[i] = new Ingredient(_data.Ingredients[i].Name, _data.Ingredients[i].FillColor);
            }
        }

        public Ingredient Get(string name)
        {
            return _ingredients.First(ingredient => ingredient.Name == name);
        }
    }
}