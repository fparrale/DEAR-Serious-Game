using System;
using System.Collections.Generic;
using Code.SaveSystem.UseCases;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;

namespace Code.SaveSystem.Controller
{
    public class SavableEntity : MonoBehaviour
    {
        public string entityId;

        public Dictionary<string, object> CaptureEntitySate()
        {
            var savableComponents = GetComponents<ISavableComponent>();
            var entityState = new Dictionary<string, object>();
            
            savableComponents.ForEach( comp => 
                entityState.Add( comp.GetType().Name, comp.CaptureComponentState())
            );

            return entityState;
        }

        public void RestoreEntityState( Dictionary<string, object> state)
        {
            var savableComponents = GetComponents<ISavableComponent>();

            savableComponents.ForEach( comp => 
                comp.RestoreState( state[comp.GetType().Name] as Dictionary<string, object>)
            );
        }

        [Button("Generate Id")]
        public void GenerateId()
        {
            entityId = Guid.NewGuid().ToString();
        }
    }
}