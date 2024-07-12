using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Code.SaveSystem.UseCases;
using Code.Utilities.VariableReference;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;

namespace Code.SaveSystem.Controller
{
    public class SaveManager : MonoBehaviour
    {
        public StringReference saveFileName;

        [Button(icon: SdfIconType.Save, ButtonHeight = 30)]
        public void SaveGame()
        {
            var allSavableEntities = FindObjectsByType<SavableEntity>(FindObjectsSortMode.None);
            var entitiesState = new Dictionary<string, object>();

            allSavableEntities.ForEach( entity => 
                entitiesState.Add(entity.entityId, entity.CaptureEntitySate())
            );

            using(var stream = File.OpenWrite(GetFilePath()))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, entitiesState);
            }

        }

        [Button(icon: SdfIconType.Save, ButtonHeight = 30)]
        public void LoadGame()
        {
            if(File.Exists(GetFilePath()) == false) return;

            var savedEntities = new Dictionary<string, object>();

            using(var stream = File.OpenRead(GetFilePath()))
            {
                var formatter = new BinaryFormatter();
                savedEntities = formatter.Deserialize(stream) as Dictionary<string, object>;
            }

            var allSavableEntities = FindObjectsByType<SavableEntity>(FindObjectsSortMode.None);

            allSavableEntities.ForEach( entity => 
                entity.RestoreEntityState( savedEntities[entity.entityId] as Dictionary<string, object>)
            );
        }

        private string GetFilePath() => Application.dataPath + "/" + saveFileName.Value;

    }


}