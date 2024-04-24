using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.Reservoirs
{
    [ShowInInspector]
    public interface IReservoir
    {
        public  ReservoirType ReservoirType { get; }
        public int StagesCount { get; }
        public SpriteRenderer[] StageRenderers { get; }
    }
}