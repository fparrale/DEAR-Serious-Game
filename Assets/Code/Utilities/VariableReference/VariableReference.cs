using UnityEngine;

namespace Code.Utilities
{
    namespace VariableReference
    {
        public abstract class VariableReference<T> : ScriptableObject
        {
            public T Value;
        }
    }
}