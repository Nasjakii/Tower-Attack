using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basis : MonoBehaviour
{
    public float hp = 100f;
    public Healthbar healthbar;

    [HideInInspector]
    public float curr_hp;
    private GameObject[] spawners;

    [HideInInspector]
    public bool game_active = true;

    private UIManager uiManager;
    void Start()
    {
        curr_hp = hp;

        spawners = GameObject.FindGameObjectsWithTag("Spawner");

        uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!spawners[0].GetComponent<Spawner>().spawn) return;

        if (!game_active) return;

        if (curr_hp <= 0f)
        {
            uiManager.SetScreen(3);
            uiManager.EditEndScreen(true, 2);
            game_active = false;
        } else
        {
            healthbar.UpdateHealtbar(hp, curr_hp);
        }


        int troops_left = 0; //check planned troops
        foreach (GameObject spawner in spawners)
        {
            troops_left += spawner.GetComponent<Spawner>().troopsToSpawn.Count;
            if (troops_left > 0) break; 
        }
        
        if(troops_left == 0) //check existring troops
        {
            GameObject[] troops = GameObject.FindGameObjectsWithTag("Troop");
            foreach (GameObject troop in troops)
            {
                if (troop.GetComponent<AIController>().idle == false)
                {
                    troops_left++;
                    break;
                }
            }
        }
        

        if (troops_left == 0)
        {
            uiManager.SetScreen(3);
            uiManager.EditEndScreen(false, 0);
            game_active = false;
        }
            

        
    }

   
}
