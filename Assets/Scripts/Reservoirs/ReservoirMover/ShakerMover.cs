using UnityEngine;

namespace Scripts.Reservoirs.ReservoirMover
{
    public class ShakerMover : IMover
    {
        private Transform _body;
        private Vector3 _defaultPositon;
        
        public ShakerMover(Transform body)
        {
            _body = body;
            _defaultPositon = _body.transform.position;
        }

        public void Move(Vector3 movePosition)
        {
            _body.transform.position = movePosition;
        }
    }
}