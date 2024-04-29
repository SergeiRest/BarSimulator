using Data;
using UnityEngine;
using Zenject;

namespace Recipes.Menu
{
    public class RecipeMenuTemplate : MonoBehaviour
    {
        [SerializeField] private Transform _container;
        private RecipeCreator _creator;
        
        [Inject]
        private void Construct(RecipeData _recipeData, DiContainer diContainer)
        {
            _creator = new RecipeCreator(_container);
            diContainer.Inject(_creator);

            _creator.Create(_recipeData);
        }
        
        private class RecipeCreator
        {
            [Inject] private RecipeTemplate _recipeTemplate;
            [Inject] private DiContainer _diContainer;

            private Transform _parent;

            public RecipeCreator(Transform parent)
            {
                _parent = parent;
            }

            public RecipeTemplate[] Create(RecipeData recipeData)
            {
                RecipeTemplate[] recipeTemplates = new RecipeTemplate[recipeData.Recipes.Length];
                for (int i = 0; i < recipeTemplates.Length; i++)
                {
                    RecipeTemplate obj = _diContainer.InstantiatePrefabForComponent<RecipeTemplate>(_recipeTemplate);
                    obj.transform.SetParent(_parent);
                    obj.transform.localScale = Vector3.one;

                    recipeTemplates[i] = obj;
                }

                return recipeTemplates;
            }
        }
    }
}