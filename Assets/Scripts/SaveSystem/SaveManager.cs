
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.VisualScripting;
using UnityEngine;
using Utils.Singleton;

namespace SaveSystem
{
    [DefaultExecutionOrder(-100)]
    public class SaveManager : BasicSingleton<SaveManager> {
        
        private string fileSavePath;

        protected override void Awake() {
             fileSavePath = $"{Application.persistentDataPath}/save.txt";
            base.Awake();
            Load();
        }

        public void Save()
        {
            using(var stream = File.Open(fileSavePath, FileMode.Create))
            {
                Debug.Log("Datos guardados en " + fileSavePath);
                var estadoEntidades = new Dictionary<string, object>();

                foreach(var entidad in GameObject.FindObjectsByType<SavableEntity>(FindObjectsSortMode.InstanceID))
                {
                    estadoEntidades[entidad.Id] = entidad.CaptureComponentsStates();
                }

                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, estadoEntidades);
            }
        }
    
        /// <summary>
        /// Metodo encargado de cargar los datos de un archivo y restaurar los datos de las Entidades
        /// </summary>
        private void Load()
        {
            if(!File.Exists(fileSavePath)) return;

            using(var stream = File.Open(fileSavePath, FileMode.OpenOrCreate))
            {
                Debug.Log("Datos cargados de " + fileSavePath);
                var formatter = new BinaryFormatter();
                var obj = formatter.Deserialize(stream) as Dictionary<string, object>;

                foreach(var entidad in GameObject.FindObjectsByType<SavableEntity>(FindObjectsSortMode.InstanceID))
                {
                    entidad.RestoreComponentsStates(obj);
                }
            }
        }

        
    }

}