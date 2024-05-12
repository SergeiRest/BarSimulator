using Data;
using GameBehavior;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameData _gameData;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameData>().FromInstance(_gameData).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<Timer>().FromNew().AsSingle().NonLazy();
        }
    }
}