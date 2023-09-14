using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class Tutorial : MonoBehaviour
{
    public GameObject textfield;
    private int textfieldIndex;
    public TextMeshProUGUI text;
    public TextMeshProUGUI headline;

    private GameObject button;

    private void Start()
    {
        PlayerPrefs.DeleteAll();
        button = GameObject.FindGameObjectWithTag("Attack Button");
        
        if (Utils.GetBool("firstLaunch"))
        {
            Debug.Log("first");
            Utils.SetBool("firstLaunch", false);
            gameObject.SetActive(true);
            button.SetActive(false);

        }
        else
        {
            Debug.Log("not first");
            gameObject.SetActive(false);
        }

        
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            textfieldIndex++;
        }
        switch (textfieldIndex)
        {
            case 0:
                headline.SetText("Welcome");
                text.SetText("Hello Commander, \nWe have to destroy the enemy's base to retake this part of Earth. \n\n\n[Space] to continue");
                
                break;
            case 1:
                headline.SetText("Camera Control");
                text.SetText("You can control the camera by using [W][A][S][D].");

                break;
            case 2:
                headline.SetText("Swapping View");
                text.SetText("Press [Tab] to swap back and forth between base and Earth.");

                if (Input.GetKeyDown(KeyCode.Tab)) textfieldIndex++;
                break;
            case 3:
                headline.SetText("Buying Troops");
                text.SetText("Select a troop and place it on one of the colored squares.");

                //bought troops
                break;
            case 4:
                headline.SetText("Attack");
                text.SetText("Head back to Earth [Tab] and start by clicking [Attack].");

                button.SetActive(true);

                break;
            default:
                gameObject.SetActive(false);
                break;
        }
    }
}
