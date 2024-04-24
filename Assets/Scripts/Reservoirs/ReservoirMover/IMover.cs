using UnityEngine;

namespace Scripts.Reservoirs.ReservoirMover
{
    public interface IMover
    {
        public void Move(Vector3 movePosition);
    }
}