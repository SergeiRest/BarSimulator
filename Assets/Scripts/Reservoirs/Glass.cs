using Scripts.Reservoirs.ReservoirMover;
using UnityEngine;
using Zenject;

namespace Scripts.Reservoirs
{
    public class Glass : Reservoir
    {
        [SerializeField] private Transform _spoon;
        [Inject]
        protected void Construct(DiContainer diContainer)
        {
            mover = new GlassMover(_spoon);
            diContainer.Inject(mover);
            base.Construct();
        }
    }
}