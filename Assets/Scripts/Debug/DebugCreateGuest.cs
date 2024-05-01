using Guests;
using UnityEngine;
using Zenject;

namespace DebugClasses
{
    public class DebugCreateGuest : MonoBehaviour
    {
        [Inject]
        private void Construct(GuestCreator guestCreator)
        {
            guestCreator.Create();
        }
    }
}