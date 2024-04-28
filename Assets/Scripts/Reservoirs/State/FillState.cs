using DG.Tweening;
using UnityEngine;

namespace Scripts.Reservoirs.State
{
    public class FillState : ReservoirState
    {
        private int fillAmount = 0;
        private int maxFill = 2;
        private SpriteRenderer[] _renderers;
        private Sequence _sequence;
        private float _fillDuration = 5f;
        
        public FillState(StateSwitcher stateSwitcher, SpriteRenderer[] renderers) : base(stateSwitcher)
        {
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
            Debug.Log("StartFilling");
            SpriteRenderer current = _renderers[fillAmount];

            _sequence.Append(current.DOFade(1, _fillDuration)).OnComplete(() =>
            {
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
}