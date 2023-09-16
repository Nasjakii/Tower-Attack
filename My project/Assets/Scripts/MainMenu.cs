using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene(1); //scene with index 1
    }
    public void quitGame()
    {
        Application.Quit();
    }

    public void LoadScene(string level_name)
    {
        if (Application.CanStreamedLevelBeLoaded("sceneName"))
        {
            SceneManager.LoadScene(level_name);
        }
        else
        {
            Debug.LogError("Wrong scene name: " + level_name);
        }
        
    }

    

    public void FlushSave()
    {
        PlayerPrefs.DeleteAll();  
    }
}
