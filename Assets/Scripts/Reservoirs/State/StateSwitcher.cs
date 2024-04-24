using System;
using System.Collections.Generic;
using Zenject;

namespace Scripts.Reservoirs.State
{
    public class StateSwitcher
    {
        [Inject] private DiContainer _diContainer;
        
        private IReservoirState _currentState;
        private Dictionary<Type, IReservoirState> _states = new Dictionary<Type, IReservoirState>();

        public IReservoirState CurrentState => _currentState;
        
        public void Add(IReservoirState state)
        {
            Type key = state.GetType();
            if(_states.ContainsKey(key))
                return;
            
            _diContainer.Inject(state);
            
            _states.Add(key, state);
        }

        public void SetState<T>() where T : IReservoirState
        {
            Type type = typeof(T);

            if (_currentState == null)
            {
                _currentState = GetState(type);
                _currentState.Enter();
                return;
            }
            
            if(_currentState.GetType() == type)
                return;

            var newState = GetState(type);
            _currentState.Exit();
            _currentState = newState;
            _currentState.Enter();
        }

        private IReservoirState GetState(Type key)
        {
            if (_states.TryGetValue(key, out var newState))
                return newState;
            else
                throw new NullReferenceException($"{key} is Missing");
        }
    }
}