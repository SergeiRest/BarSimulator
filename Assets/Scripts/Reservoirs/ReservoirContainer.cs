using System.Collections.Generic;
using Data;
using UnityEngine;
using Zenject;

namespace Scripts.Reservoirs
{
    public class ReservoirContainer
    {
        private Dictionary<(ReservoirType, int), IReservoir> _reservoirs =
            new Dictionary<(ReservoirType, int), IReservoir>();

        [Inject]
        private void Construct(ReservoirData data)
        {
            foreach (var reservoir in data.Reservoirs)
            {
                _reservoirs.Add((reservoir.ReservoirType, reservoir.StagesCount), reservoir);
            }
        }
    }
}