using Data;
using Recipes.Menu;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class RecipeInstaller : MonoInstaller
    {
        [SerializeField] private RecipeData _recipeData;
        [SerializeField] private RecipeTemplate _recipeTemplate;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<RecipeData>().FromInstance(_recipeData).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<RecipeTemplate>().FromInstance(_recipeTemplate).AsSingle().NonLazy();
        }
    }
}