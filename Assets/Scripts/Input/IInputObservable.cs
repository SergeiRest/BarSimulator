using UnityEngine;

namespace Input
{
    public interface IInputObservable
    {
        public void AddObserver(IInputObserver observer);
        public IInputObserver SelectObservable(Vector3 position);
    }
}