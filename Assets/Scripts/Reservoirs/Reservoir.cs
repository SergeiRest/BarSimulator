using System;
using Input;
using Scripts.Reservoirs.ReservoirMover;
using Scripts.Reservoirs.State;
using UnityEngine;
using Zenject;

namespace Scripts.Reservoirs
{
    public abstract class Reservoir : MonoBehaviour, IReservoir, IInputObserver
    {
        [SerializeField] private ReservoirType _reservoirType;
        [SerializeField] private int _stageCount;
        [SerializeField] private SpriteRenderer[] _stageRenderers;

        [Inject] private IInputObservable _inputObservable;
        [Inject] private DiContainer _diContainer;

        private int _currentStage = 0;
        private StateSwitcher _stateSwitcher;

        protected IMover mover;

        public ReservoirType ReservoirType => _reservoirType;
        public int StagesCount => _stageCount;
        public SpriteRenderer[] StageRenderers => _stageRenderers;
        public Transform Transform => transform;

        protected virtual void Construct()
        {
            _inputObservable.AddObserver(this);
            InitStateMachine();
        }
        
        public void Interact()
        {
            _stateSwitcher.CurrentState.Interact();
        }

        private void InitStateMachine()
        {
            _stateSwitcher = new StateSwitcher();
            _diContainer.Inject(_stateSwitcher);
            
            _stateSwitcher.Add(new SelectionState(_stateSwitcher));
            _stateSwitcher.Add(new FillState(_stateSwitcher));
            _stateSwitcher.Add(new DragState(_stateSwitcher, mover));
            _stateSwitcher.SetState<SelectionState>();
        }
    }
}