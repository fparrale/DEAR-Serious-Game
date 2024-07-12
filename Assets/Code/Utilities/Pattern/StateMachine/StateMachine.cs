
using UnityEngine;

namespace Utilities.Pattern.StateMachine
{
    public abstract class StateMachine<T> : MonoBehaviour
    {
        public  State<T> currentState;
    }
}