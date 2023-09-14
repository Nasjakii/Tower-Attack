using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class Utils: MonoBehaviour
{
    public static void SetInt(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }
    public static int GetInt(string key)
    {
        return PlayerPrefs.GetInt(key);
    }


    public static void SetSting(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
    }
    public static string GetString(string key)
    {
        return PlayerPrefs.GetString(key);
    }


    public static void SetBool(string key, bool value)
    {
        if (value)
        {
            PlayerPrefs.SetInt(key, 1);
        } else
        {
            PlayerPrefs.SetInt(key, 0);
        }
        
    }
    public static bool GetBool(string key)
    {
        return PlayerPrefs.GetInt(key) == 1;
    }

}
