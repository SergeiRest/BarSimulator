using Guests;
using Input;
using UnityEngine;
using Zenject;

namespace Scripts.Reservoirs.Interactables
{
    public enum Size
    {
        Medium,
        Big,
        Universal,
        
    }
    
    
    public class InteractiveReservoir : MonoBehaviour, IInputObserver
    {
        [Inject] private ReservoirCreator _reservoirCreator;
        [Inject] private ReservoirPlacer _placer;
        [Inject] private GuestHandler _guestHandler;

        [SerializeField] private ReservoirType _reservoirType;
        [SerializeField] private Size _size;

        public Transform Transform => transform;

        [Inject]
        private void Construct(IInputObservable inputObservable)
        {
            inputObservable.AddObserver(this);
        }
        
        public void Interact()
        {
            var cocktailSize = _guestHandler.Guest.SelectedCocktail.Size;
            int cocktailStages = _guestHandler.Guest.SelectedCocktail.StagesCount;
            if(cocktailSize != Size.Universal && _size != cocktailSize)
                return;
            
            int multiplier = 0;
            if (cocktailSize == Size.Universal)
                multiplier = _size == Size.Medium ? 1 : 2;
            else
                multiplier = 1;
            
            _placer.Select(_reservoirType, cocktailStages * multiplier);
        }
    }
}