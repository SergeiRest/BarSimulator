using Scripts.Reservoirs.ReservoirMover;
using Zenject;

namespace Scripts.Reservoirs
{
    public class Shaker : Reservoir
    {
        [Inject]
        protected void Construct(DiContainer diContainer)
        {
            mover = new ShakerMover(transform);
            diContainer.Inject(mover);
            base.Construct();
        }
    }
}