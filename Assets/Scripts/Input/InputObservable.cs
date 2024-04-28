using System;
using System.Collections.Generic;
using UnityEngine;

namespace Input
{
    public class InputObservable : IInputObservable
    {
        private List<IInputObserver> _observables = new List<IInputObserver>();
        
        public void AddObserver(IInputObserver observer)
        {
            _observables.Add(observer);
        }

        public IInputObserver SelectObservable(Vector3 position)
        {
            if (_observables.Count == 0)
            {
                throw new NullReferenceException("None of observables");
            }

            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
            worldPosition.z = 0;
            
            IInputObserver observer = _observables[0];
            
            for (int i = 1; i < _observables.Count; i++)
            {
                if ((_observables[i].Transform.position - worldPosition).sqrMagnitude <
                    (observer.Transform.position - worldPosition).sqrMagnitude)
                {
                    observer = _observables[i];
                }
            }

            return observer;
        }
    }
}