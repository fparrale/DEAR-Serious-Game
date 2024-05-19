
using System;
using UnityEngine;

namespace Utils.StatePattern
{
    public abstract class State<T>
    {
        public T context;

        public State(T context)
        {
            this.context = context;
        }
        
        public abstract void OnEnterState();
        public abstract void OnUpdateState();
        public abstract void OnExitState();

      
    }
}