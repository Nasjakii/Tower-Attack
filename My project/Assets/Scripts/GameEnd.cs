using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadNext()
    {
        string scene_name = SceneManager.GetActiveScene().name;

        string next_scene = "";
        switch(scene_name)
        {
            case ("Tutorial 1"):
                next_scene = "Tutorial 2";
                break;
            case ("Tutorial 2"):
                next_scene = "Tutorial 3";
                break;
            case ("Tutorial 3"):
                next_scene = "MainMenu";
                break;

            default:
                next_scene = "MainMenu";
                break;
        }

        if (next_scene != "MainMenu") PlayerPrefs.SetString("last_loaded_scene", next_scene);
        SceneManager.LoadScene(next_scene);
    }
}
