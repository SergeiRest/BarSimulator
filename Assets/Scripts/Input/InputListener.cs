using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Input
{
    public class InputListener : MonoBehaviour, IPointerDownHandler,IPointerUpHandler, IDragHandler
    {
        [Inject] private IInputObservable _inputObservable;
        [Inject] private DragHandler _dragHandler;

        private IInputObserver _observer;
        
        public void OnPointerDown(PointerEventData eventData)
        {
            _observer = _inputObservable.SelectObservable(eventData.position);
            _observer.Interact();
        }

        public void OnPointerUp(PointerEventData eventData)
        { 
            if(_observer == null)
                return;
        }

        public void OnDrag(PointerEventData eventData)
        {
            _dragHandler.Update(eventData.position);
        }
    }
}