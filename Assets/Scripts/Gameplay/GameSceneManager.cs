using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils.Singleton;


namespace Gameplay
{
    public class GameSceneManager : BasicSingleton<GameSceneManager>
    {
        public void LoadScene(int sceneBuildIndex)
        {
            SceneManager.LoadScene(sceneBuildIndex);
        }

        public void QuitApplication()
        {
            Application.Quit();
        }
    }
    
}
