using System.Collections.Generic;
using DG.Tweening;
using Ingredients;
using UnityEngine;
using Zenject;

namespace Scripts.Reservoirs.State
{
    public class FillState : ReservoirState
    {
        [Inject] private IngredientSelector _selector;

        private int fillAmount = 0;
        private int maxFill = 2;
        private float _fillDuration = 2f;
        private SpriteRenderer[] _renderers;
        private Sequence _sequence;
        private Filler _filler;
        
        public FillState(StateSwitcher stateSwitcher, SpriteRenderer[] renderers, Filler filler) : base(stateSwitcher)
        {
            _filler = filler;
            _renderers = renderers;
        }

        public override void Enter()
        {
            Debug.Log("Enter fill state");
            Fill();
        }

        public override void Exit()
        {
        }

        public override void Interact()
        {
            if(_sequence != null)
                return;
            
            Fill();
        }

        private void Fill()
        {
            _sequence = DOTween.Sequence();
            Ingredient ingredient = _selector.SelectedIngredient;
            Debug.Log("StartFilling");
            
            SpriteRenderer current = _renderers[fillAmount];
            Color color = ingredient.Color;
            color.a = 0;
            current.color = color;

            _sequence.Append(current.DOFade(1, _fillDuration)).OnComplete(() =>
            {
                _filler.Add(ingredient);
                fillAmount++;
                ChangeState();
            });
        }

        private void ChangeState()
        {
            if(fillAmount >= maxFill)
                StateSwitcher.SetState<DragState>();
            else
                StateSwitcher.SetState<SelectionState>();
        }
    }

    public class Filler
    {
        private List<Ingredient> fill = new List<Ingredient>();

        public List<Ingredient> Container => fill;

        public void Add(Ingredient ingredient)
            => fill.Add(ingredient);
    }
}