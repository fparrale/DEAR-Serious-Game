using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace Gameplay
{
    public class FileValidator : MonoBehaviour {

        [Required]
        public GameSceneManager sceneManager;

        [Required]
        public CsvRequirementProvider reqProvider;

        [Required]
        public GameObject errorFileTxt;
        
        private void Start() {
             if(reqProvider.ExistFile() == false)
                reqProvider.CreateFile();
        }

        public void SelectPlay()
        {
            if(reqProvider.ExistFile() == false)
                reqProvider.CreateFile();

            if(reqProvider.ValidateFile() == false)
            {
                errorFileTxt.SetActive(true);
                return;
            }

            sceneManager.LoadScene(1);
        }


        public void RewiteFileAgain() => reqProvider.CreateFile();

        


    }
}