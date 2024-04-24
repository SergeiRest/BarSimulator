namespace Scripts.Reservoirs.State
{
    public abstract class ReservoirState : IReservoirState
    {
        private StateSwitcher _stateSwitcher;

        public StateSwitcher StateSwitcher => _stateSwitcher;
        
        public ReservoirState(StateSwitcher stateSwitcher)
        {
            _stateSwitcher = stateSwitcher;
        }

        public abstract void Enter();

        public abstract void Exit();
        public abstract void Interact();
    }
}