using Data;
using Ingredients;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class IngredientsInstaller : MonoInstaller
    {
        [SerializeField] private IngredientsData _ingredientsData;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<IngredientsData>().FromInstance(_ingredientsData).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<IngredientsContainer>().FromNew().AsSingle().NonLazy();
        }
    }
}