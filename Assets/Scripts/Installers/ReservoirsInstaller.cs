using Data;
using Scripts.Reservoirs;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class ReservoirsInstaller : MonoInstaller
    {
        [SerializeField] private ReservoirData _reservoirData;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ReservoirData>().FromInstance(_reservoirData).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ReservoirContainer>().FromNew().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ReservoirCreator>().FromNew().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ReservoirPlacer>().FromNew().AsSingle().NonLazy();
        }
    }
}