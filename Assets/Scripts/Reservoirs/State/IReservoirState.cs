namespace Scripts.Reservoirs.State
{
    public interface IReservoirState
    {
        public StateSwitcher StateSwitcher { get; }

        public void Enter();
        public void Exit();
        public void Interact();
    }
}