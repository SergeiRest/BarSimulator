using Data;
using Zenject;

namespace Guests
{
    public class GuestCreator
    {
        [Inject] private GuestsData _guestsData;
        [Inject] private GuestHandler _guestHandler;
        [Inject] private DiContainer _diContainer;
        
        public void Create()
        {
            var guestTemplate = _diContainer.InstantiatePrefabForComponent<AbstractGuestTemplate>(_guestsData.BaseGuest);
            _guestHandler.Add(guestTemplate);
        }
    }
}