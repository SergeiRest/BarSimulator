using Input;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class InputInstaller : MonoInstaller
    {
        [SerializeField] private InputListener _inputListener;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<DragHandler>().FromNew().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<InputObservable>().FromNew().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<InputListener>().FromInstance(_inputListener).AsSingle().NonLazy();
        }
    }
}