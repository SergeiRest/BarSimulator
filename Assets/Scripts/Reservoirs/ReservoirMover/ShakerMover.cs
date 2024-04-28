using System;
using UnityEngine;

namespace Scripts.Reservoirs.ReservoirMover
{
    public class ShakerMover : IMover
    {
        private Transform _body;
        private Vector3 _defaultPositon;
        private float currentTime = 0;
        private float maxTime = 1;

        public event Action OnComplete;
        
        public ShakerMover(Transform body)
        {
            _body = body;
            _defaultPositon = _body.transform.position;
        }

        public void Move(Vector3 movePosition)
        {
            _body.transform.position = movePosition;
            currentTime += Time.deltaTime;

            if (currentTime >= maxTime)
            {
                currentTime = 0;
                OnComplete?.Invoke();
            }
        }

        public void SetToDefault()
        {
            _body.position = _defaultPositon;
        }

    }
}