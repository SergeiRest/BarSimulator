using UnityEngine;

namespace Scripts.Reservoirs.State
{
    public class SelectionState : ReservoirState
    {
        public SelectionState(StateSwitcher stateSwitcher) : base(stateSwitcher)
        {
        }

        public override void Enter()
        {
            Debug.Log("Enter basic state");
        }

        public override void Exit()
        {
            // TODO в будущем запрещать выбор чем заполнять
        }

        public override void Interact()
        {
            StateSwitcher.SetState<FillState>();
        }
    }
}