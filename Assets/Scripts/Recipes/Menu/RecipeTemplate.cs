using Data;
using TMPro;
using UnityEngine;

namespace Recipes.Menu
{
    public class RecipeTemplate : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _ingredientPrefab;
        [SerializeField] private Transform _ingredientsParent;

        public void Init(Recipe recipe)
        {
            _name.text = recipe.Name;

            foreach (var ingredient in recipe.Ingridients)
            {
                var ingredientObject = Object.Instantiate(_ingredientPrefab, _ingredientsParent, true);
                ingredientObject.transform.localScale = Vector3.one;
                ingredientObject.text = ingredient;
            }
        }
    }
}