using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "GameData", menuName = "Data/GameData")]
    public class GameData : ScriptableObject
    {
        [field: SerializeField] public float HourDuration { get; private set; }
        [field: SerializeField] public int DayHours { get; private set; }
    }
}