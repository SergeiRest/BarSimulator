using Recipes.Menu;
using UnityEngine;
using Zenject;

namespace DebugClasses
{
    public class DebugRecipeShower : MonoBehaviour
    {
        [Inject] private DiContainer _diContainer;
        [SerializeField] private RecipeMenuTemplate _menuTemplate;

        public void Show()
        {
            _diContainer.InstantiatePrefabForComponent<RecipeMenuTemplate>(_menuTemplate);
        }
    }
}