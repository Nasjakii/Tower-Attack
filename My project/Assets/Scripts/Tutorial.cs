using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public GameObject textfield;
    private int textfieldIndex;
    public TextMeshProUGUI text;
    public TextMeshProUGUI headline;

    private GameObject button;
    public float timeBeforeContinue = 1f;

    private float timer = 0;
    private string[] tutorial_text;
    private string[] tutorial_headline;


    private void Start()
    {
        
        button = GameObject.FindGameObjectWithTag("Attack Button");

        string scene_name = SceneManager.GetActiveScene().name;
        if (scene_name == "Tutorial 1")
        {
            tutorial_text = new string[5];
            tutorial_headline = new string[5]; 
            tutorial_headline[0] = "Welcome";
            tutorial_text[0] = "Hello Commander, \nWe have to destroy the enemy's base to retake this part of Earth. \n\n\n[Space] to continue";
            tutorial_headline[1] = "Camera Control";
            tutorial_text[1] = "You can control the camera by using [W,A,S,D].";
            tutorial_headline[2] = "Swapping View";
            tutorial_text[2] = "Press [Tab] to swap back and forth between base and Earth.";
            tutorial_headline[3] = "Buying Troops";
            tutorial_text[3] = "Select a troop and place it on one of the colored squares.";
            tutorial_headline[4] = "Attack";
            tutorial_text[4] = "Head back to Earth [Tab] and start by clicking [Attack].";
        }
        if (scene_name == "Tutorial 2")
        {
            tutorial_text = new string[2];
            tutorial_headline = new string[2];
            tutorial_headline[0] = "Welcome";
            tutorial_text[0] = "Hello Commander, \nThis time we have to deal with stun turrets, these can be countered by the Speedster Troop.";
            tutorial_headline[1] = "Objective";
            tutorial_text[1] = "Build the Speedster Troop and attack the enemies.";
        }
        if (scene_name == "Tutorial 3")
        {
            tutorial_text = new string[3];
            tutorial_headline = new string[3];
            tutorial_headline[0] = "Welcome";
            tutorial_text[0] = "Hello Commander, \nThis time we have to deal with Drones, build by the Drone Hub. \nThey can be countered by the Rocket Guy, he is able to shoot them.";
            tutorial_headline[1] = "Beacons";
            tutorial_text[1] = "By clicking the Beacons infront of the Troopfields you can change the position where the Troops get dropped off.";
            tutorial_headline[2] = "Objective";
            tutorial_text[2] = "Build the Rocket Guy Troop, focus them on one weaker side and attack the enemies.";
        }

    }

    void Update()
    {
        if (timer > 0) timer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && timer <= 0)
        {
            textfieldIndex++;
            timer = timeBeforeContinue;
        }


        if (textfieldIndex >= tutorial_headline.Length)
        {
            gameObject.SetActive(false);
            return;
        }
        headline.text = tutorial_headline[textfieldIndex];
        text.text = tutorial_text[textfieldIndex];
    
    }
}
