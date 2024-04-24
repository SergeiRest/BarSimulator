using Scripts.Reservoirs.ReservoirMover;
using Zenject;

namespace Scripts.Reservoirs
{
    public class Glass : Reservoir
    {
        [Inject]
        protected void Construct(DiContainer diContainer)
        {
            mover = new GlassMover(transform);
            diContainer.Inject(mover);
            base.Construct();
        }
    }
}