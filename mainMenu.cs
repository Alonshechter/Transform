using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour {

    private AsyncOperation loadLaevel;

    private void Start()
    {
        sceneStart();
    }

   public void loadScene()
    {
        loadLaevel.allowSceneActivation = true;
    }

    private void sceneStart()
    {
        switch(SceneManager.GetActiveScene().buildIndex)
        {
            case (0):
                loadLaevel = SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
                loadLaevel.allowSceneActivation = false;
                break;

            case (1):
                loadLaevel = SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
                loadLaevel.allowSceneActivation = false;
                break;
        }
    }
}
