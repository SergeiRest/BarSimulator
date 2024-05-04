using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Scripts.Reservoirs
{
    public class ReservoirPlacer
    {
        [Inject] private ReservoirCreator _creator;
        
        private Reservoir _placed;

        public void Select(ReservoirType type, int size)
        {
            if (_placed != null)
            {
                Object.Destroy(_placed.gameObject);
            }

            _placed = _creator.Create((type, size));
        }
    }
}