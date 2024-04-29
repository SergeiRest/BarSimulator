using Data;
using Scripts.Reservoirs;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Recipes.Menu
{
    public class RecipeTemplate : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _ingredientPrefab;
        [SerializeField] private Transform _ingredientsParent;

        [Inject] private ReservoirCreater _reservoirCreator;

        private Recipe _recipe;
        
        public void Init(Recipe recipe)
        {
            _recipe = recipe;

            _name.text = recipe.Name;

            foreach (var ingredient in recipe.Ingridients)
            {
                var ingredientObject = Object.Instantiate(_ingredientPrefab, _ingredientsParent, true);
                ingredientObject.transform.localScale = Vector3.one;
                ingredientObject.text = ingredient;
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _reservoirCreator.Create((_recipe.ReservoirType, _recipe.StagesCount));
        }
    }
}