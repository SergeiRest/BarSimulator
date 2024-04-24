using System;
using UnityEngine;

namespace Input
{
    public class DragHandler
    {
        public Action<Vector3> DragUpdate;

        public void Update(Vector3 position)
        {
            Vector3 newPos = Camera.main.ScreenToWorldPoint(position);
            newPos.z = 0;
            DragUpdate?.Invoke(newPos);
        }
    }
}