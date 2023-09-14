using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basis : MonoBehaviour
{
    public float hp = 100f;
    public Healthbar healthbar;

    [HideInInspector]
    public float curr_hp;
    void Start()
    {
        curr_hp = hp;
    }

    // Update is called once per frame
    void Update()
    {
        if (curr_hp <= 0f)
        {
            Debug.Log("you win!");
        } else
        {
            healthbar.UpdateHealtbar(hp, curr_hp);
        }
    }
}
