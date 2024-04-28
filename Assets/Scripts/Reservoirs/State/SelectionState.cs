using Ingredients;
using UnityEngine;
using Zenject;

namespace Scripts.Reservoirs.State
{
    public class SelectionState : ReservoirState
    {
        [Inject] private IngredientSelector _ingredientSelector;
        
        public SelectionState(StateSwitcher stateSwitcher) : base(stateSwitcher)
        {
        }

        public override void Enter()
        {
            Debug.Log("Enter basic state");
        }

        public override void Exit()
        {
            // TODO в будущем запрещать выбор чем заполнять
        }

        public override void Interact()
        {
            bool isEmpty = _ingredientSelector.IsEmpty;
            if (isEmpty)
            {
                Debug.Log("No one selected ingredient");
                return;
            }
            StateSwitcher.SetState<FillState>();
        }
    }
}