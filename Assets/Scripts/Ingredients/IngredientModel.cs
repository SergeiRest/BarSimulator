using Input;
using UnityEngine;
using Zenject;

namespace Ingredients
{
    public class IngredientModel : MonoBehaviour, IInputObserver
    {
        [Inject] private IngredientSelector _selector;

        [SerializeField] private string _ingredientName;
        
        private Ingredient _ingredient;

        public Transform Transform => transform;

        [Inject]
        private void Construct(IInputObservable observable, IngredientsContainer container)
        {
            observable.AddObserver(this);
            _ingredient = container.Get(_ingredientName);
        }
        
        public void Interact()
        {
            _selector.Select(_ingredient);
            Debug.Log($"Selected {_ingredient.Name}");
        }
    }

    public class Ingredient
    {
        public string Name { get; private set; }
        public Color Color { get; private set; }

        public Ingredient(string name, Color color)
        {
            Name = name;
            Color = color;
        }
    }
}