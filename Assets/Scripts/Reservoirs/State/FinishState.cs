using Guests;
using Zenject;

namespace Scripts.Reservoirs.State
{
    public class FinishState : ReservoirState
    {
        [Inject] private GuestHandler _guestHandler;

        private Filler _filler;
        
        public FinishState(StateSwitcher stateSwitcher, Filler filler) : base(stateSwitcher)
        {
            _filler = filler;
        }

        public override void Enter()
        {
            _guestHandler.Guest.CheckCocktail(_filler);
        }

        public override void Exit()
        {
        }

        public override void Interact()
        {
        }
    }
}