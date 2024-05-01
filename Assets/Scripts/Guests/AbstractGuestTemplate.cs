using System;
using System.Diagnostics;
using Data;
using UnityEngine;

namespace Guests
{
    public abstract class AbstractGuestTemplate : MonoBehaviour
    { 
        protected Recipe _selected;

        public Recipe Selected => _selected;

        protected abstract void Init();

        private void Awake()
        {
            Init();
        }
    }
}