using UnityEngine;
using Zenject;

namespace Scripts.Reservoirs
{
    public class ReservoirCreator
    {
        [Inject] private DiContainer _diContainer;
        [Inject] private ReservoirContainer _reservoirContainer;

        public void Create((ReservoirType, int) touple)
        {
            Reservoir prefab = _reservoirContainer.Get(touple);

            Reservoir obj = _diContainer.InstantiatePrefabForComponent<Reservoir>(prefab);
            obj.Transform.localPosition = Vector3.zero;
        }
    }
}