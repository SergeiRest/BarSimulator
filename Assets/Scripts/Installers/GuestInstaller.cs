using Data;
using Guests;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GuestInstaller : MonoInstaller
    {
        [SerializeField] private GuestsData _guestsData;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GuestHandler>().FromNew().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<GuestCreator>().FromNew().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<GuestsData>().FromInstance(_guestsData).AsSingle().NonLazy();
        }
    }
}