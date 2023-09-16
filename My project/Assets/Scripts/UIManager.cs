using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject MainScreen;
    public GameObject ShopUI;
    public GameObject Tutorial;
    public GameObject GameEndScreen;

    public void SetActiveScreen(int screen_index, bool state)
    {
        switch (screen_index)
        {
            case 0:
                MainScreen.SetActive(state);
                break;
            case 1:
                ShopUI.SetActive(state);
                break;
            case 2:
                Tutorial.SetActive(state);
                break;
            case 3:
                GameEndScreen.SetActive(state);
                break;
        }
    }

    public void SetScreen(int screen_index)
    {
        SetActiveScreen(0, false);
        SetActiveScreen(1, false);
        SetActiveScreen(2, false);
        SetActiveScreen(3, false);

        SetActiveScreen(screen_index, true);
    }

    public void EditEndScreen(bool win, int score)
    {
        GameObject lose_img = GameEndScreen.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject;
        GameObject win_img = GameEndScreen.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject;

        lose_img.SetActive(!win);
        win_img.SetActive(win);


        Stars stars = GameEndScreen.transform.GetChild(2).gameObject.GetComponent<Stars>();
        stars.SetScore(score);
    }
}
