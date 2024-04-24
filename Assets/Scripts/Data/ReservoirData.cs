using Scripts.Reservoirs;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "ReservoirData", menuName = "Data/ReservoirData")]
    public class ReservoirData : SerializedScriptableObject
    {
        public Reservoir[] Reservoirs;
    }

    [System.Serializable]
    public struct ReservoirTemplate
    {
        public IReservoir Reservoir;
    }
}