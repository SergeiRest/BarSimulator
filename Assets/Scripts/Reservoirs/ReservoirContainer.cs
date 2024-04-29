using System.Collections.Generic;
using Data;
using Zenject;

namespace Scripts.Reservoirs
{
    public class ReservoirContainer
    {
        private Dictionary<(ReservoirType, int), Reservoir> _reservoirs =
            new Dictionary<(ReservoirType, int), Reservoir>();

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