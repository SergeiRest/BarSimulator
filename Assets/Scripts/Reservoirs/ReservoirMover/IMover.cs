using System;
using UnityEngine;

namespace Scripts.Reservoirs.ReservoirMover
{
    public interface IMover
    {
        public void Move(Vector3 movePosition);
        public void SetToDefault();
        public event Action OnComplete;
    }
}