using System;
using UnityEngine;

namespace Scripts.Reservoirs.ReservoirMover
{
    public class GlassMover : IMover
    {
        private Transform _movableObject;
        private Vector3 _defaultPositon;
        private float currentTime = 0;
        private float maxTime = 2;

        private float minClamp = -1;
        private float maxClamp = 1;

        public event Action OnComplete;

        
        public GlassMover(Transform movableObject)
        {
            _movableObject = movableObject;
            _defaultPositon = movableObject.transform.localPosition;
            Debug.Log(_defaultPositon);
        }

        public void Move(Vector3 movePosition)
        {
            Vector3 toMove = new Vector3(movePosition.x, _movableObject.position.y);
            toMove.x = Mathf.Clamp(toMove.x, minClamp, maxClamp);
            
            _movableObject.transform.position = toMove;
            currentTime += Time.deltaTime;

            if (currentTime >= maxTime)
            {
                currentTime = 0;
                OnComplete?.Invoke();
            }
        }

        public void SetToDefault()
        {
            _movableObject.transform.localPosition = _defaultPositon;
        }
    }
}