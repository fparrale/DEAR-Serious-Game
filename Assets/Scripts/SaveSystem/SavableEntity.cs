
using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;

namespace SaveSystem
{

    public class SavableEntity : MonoBehaviour
    {
        [SerializeField]
        private string id = string.Empty;

        public string Id => id;


        [Button("Generar Id")]
        public void GenerarId()
        {
            if(id == string.Empty) id = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Obtiene los estados de todos los componentes del GameObject y los devuelve en un Dictionary
        /// </summary>
        /// <returns>Dictionary con los datos de los componentes</returns>
        public Dictionary<string, object> CaptureComponentsStates()
        {
            var estadosComponentes = new Dictionary<string, object>();

            foreach (var componente in GetComponents<ISavableComponent>())
            {
                estadosComponentes[componente.GetType().ToString()] = componente.CaptureState();
            }

            return estadosComponentes;
        }


        /// <summary>
        /// Obtiene los componentes <see cref="ISavableComponent"/> y los restaura al estado guardado
        /// </summary>
        /// <param name="estadosComponentes"></param>
        public void RestoreComponentsStates(Dictionary<string, object> states)
        {
            if( states.TryGetValue(id, out object objEntityState) == false) return;

            var entityState = (Dictionary<string, object>) objEntityState;

            foreach (var componente in GetComponents<ISavableComponent>())
            {

                string tipoComponente = componente.GetType().ToString();
                
                if(entityState.TryGetValue(tipoComponente, out object obj))
                {
                    componente.RestoreState(obj);
                }

            }
        }
    }
}