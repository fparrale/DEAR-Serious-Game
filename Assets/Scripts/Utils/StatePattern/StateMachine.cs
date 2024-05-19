
using UnityEngine;

namespace Utils.StatePattern
{
    public abstract class StateMachine<T> : MonoBehaviour
    {
        public  State<T> currentState;
    }
}