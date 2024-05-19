
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;


namespace Utils.Events
{
    [CreateAssetMenu(fileName = "EventRegistrySO", menuName = "Game/Event Registry", order = 0)]
    public class EventRegistrySO : ScriptableObject 
    {
        [SerializeField]
        private List<EventListener> events;

        public void SubscribeEvent(EventListener eventListener)
        {
            if(events.Contains(eventListener)) return;
            events.Add(eventListener);
        }

        public void UnsubscribeEvent(EventListener eventListener) =>
            events.Remove(eventListener);


        [Button]
        public void InvokeEvents()
        {
            events.ForEach( e => e.events.Invoke());
        }


    }
}