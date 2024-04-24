using Input;
using Scripts.Reservoirs.ReservoirMover;
using UnityEngine;
using Zenject;

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
    
    public class FillState : ReservoirState
    {
        private int fillAmount = 0;
        private int maxFill = 2;
        
        public FillState(StateSwitcher stateSwitcher) : base(stateSwitcher)
        {
        }

        public override void Enter()
        {
            Debug.Log("Enter fill state");
        }

        public override void Exit()
        {
        }

        public override void Interact()
        {
            fillAmount++;
            
            if(fillAmount >= maxFill)
                StateSwitcher.SetState<DragState>();
            else
                StateSwitcher.SetState<SelectionState>();
        }
    }
    
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
            Debug.Log("Etner drag state");
        }

        public override void Exit()
        {
            _dragHandler.DragUpdate -= _mover.Move;
        }

        public override void Interact()
        {
        }
    }
}