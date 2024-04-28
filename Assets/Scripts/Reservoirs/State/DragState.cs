using Input;
using Scripts.Reservoirs.ReservoirMover;
using UnityEngine;
using Zenject;

namespace Scripts.Reservoirs.State
{
    public class DragState : ReservoirState
    {
        [Inject] private DragHandler _dragHandler;
        private IMover _mover;
        
        public DragState(StateSwitcher stateSwitcher, IMover mover) : base(stateSwitcher)
        {
            _mover = mover;
        }

        public override void Enter()
        {
            _dragHandler.DragUpdate += _mover.Move;
            _mover.OnComplete += Complete;
            Debug.Log("Etner drag state");
        }

        public override void Exit()
        {
            _dragHandler.DragUpdate -= _mover.Move;
        }

        public override void Interact()
        {
        }

        private void Complete()
        {
            _dragHandler.DragUpdate -= _mover.Move;
            _mover.SetToDefault();
            Debug.Log("A");
        }
    }
}