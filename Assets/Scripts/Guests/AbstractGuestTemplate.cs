using System;
using System.Diagnostics;
using Data;
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
    }
}