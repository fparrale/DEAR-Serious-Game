using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Scripting;

namespace Utils.Events
{
    
    public class EventListener : MonoBehaviour 
    {
        [RequiredMember]
        public EventRegistrySO eventRegistry;
        public UnityEvent events;

        private void Awake() {
            if(eventRegistry == null) return;

            eventRegistry.SubscribeEvent(this);
        }

        private void OnDisable() {
            if(eventRegistry == null) return;

            eventRegistry.UnsubscribeEvent(this);
        }
    }
}