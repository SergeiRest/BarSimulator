using Guests;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "GuestData", menuName = "Data/GuestData")]
    public class GuestsData : ScriptableObject
    {
        [field: SerializeField] public BaseGuestTemplate BaseGuest;
    }
}