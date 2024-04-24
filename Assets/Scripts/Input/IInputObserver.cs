using UnityEngine;

namespace Input
{
    public interface IInputObserver
    {
        public Transform Transform { get; }
        public void Interact();
    }
}