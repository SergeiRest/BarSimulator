using Data;
using Scripts.Reservoirs.State;
using UnityEngine;

namespace Guests
{
    public abstract class AbstractGuestTemplate : MonoBehaviour
    { 
        protected Recipe _selectedCocktail;

        public Recipe SelectedCocktail => _selectedCocktail;

        protected abstract void Init();

        private void Awake()
        {
            Init();
        }

        public void CheckCocktail(Filler filler)
        {
            if (filler.Container.Count < _selectedCocktail.StagesCount)
            {
                Debug.Log("Xyeta");
                return;
            }

            bool value = true;
            for (int i = 0; i < filler.Container.Count; i++)
            {
                value &= filler.Container[i].Name == _selectedCocktail.Ingridients[i];
            }
            
            Debug.Log(value);
        }
    }
}