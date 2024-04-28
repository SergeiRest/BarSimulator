using System;
using UnityEngine;

namespace Scripts.Reservoirs.ReservoirMover
{
    public class GlassMover : IMover
    {
        private Transform _movableObject;

        public event Action OnComplete;

        
        public GlassMover(Transform movableObject)
        {
            _movableObject = movableObject;
        }

        public void Move(Vector3 movePosition)
        {
            
        }

        public void SetToDefault()
        {
            
        }
    }
}