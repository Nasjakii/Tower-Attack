using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void playGame()
    {
        string last_loaded = PlayerPrefs.GetString("last_loaded_scene");

        if (last_loaded == "") LoadScene("Tutorial 1"); else LoadScene(last_loaded);
    }
    public void quitGame()
    {
        Application.Quit();
    }

    public void LoadScene(string scene_name)
    {
        if (Application.CanStreamedLevelBeLoaded(scene_name))
        {
            PlayerPrefs.SetString("last_loaded_scene", scene_name);
            SceneManager.LoadScene(scene_name);
            
        }
        else
        {
            Debug.LogError("Wrong scene name: " + scene_name);
        }
        
    }

    

    public void FlushSave()
    {
        PlayerPrefs.DeleteAll();  
    }
}
