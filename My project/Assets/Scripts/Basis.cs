using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basis : MonoBehaviour
{
    public float hp = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0f)
        {
            Debug.Log("you win!");
        }
    }
}
