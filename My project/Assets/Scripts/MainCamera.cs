using System;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MainCamera : MonoBehaviour
{

    private bool doMovement = true;
    public float ySpeed = 10f;
    private float minY = 10f;
    private float maxY = 80f;

    public float rotate_speed = 1;

    private float width = 30f;

    private float circlePos = 0f;
    private float circleIncrement = 0.001f;

    private float rotator = 360f / (2 * Mathf.PI) * 0.001f;

    private int field = 1;
    public int switchSpeed = 100;
    private bool switching = false;
    private float moved = 0f;

    public GameObject gameUI;
    public GameObject baseUI;

    private void Start()
    {
        circleIncrement = circleIncrement * rotate_speed;
        rotator = rotator * rotate_speed;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
            doMovement = !doMovement;

        if (!doMovement)
            return;

        //get position of the middle of the board
        GameObject fieldCenter = GameObject.Find("FieldCenter");
        Vector3 center_pos = fieldCenter.transform.position;

        

        

        if (Input.GetKeyUp("tab") && !switching)
        {
            switching = true;
            field *= -1;

        }
        if (switching)
        {
            if (Mathf.Abs(moved) >= 200)
            {
                switching = false;
                moved = 0f;
                return;
            }

            Vector3 dir = new Vector3(0,0,field); 
            fieldCenter.transform.Translate(dir.normalized * switchSpeed * Time.deltaTime, Space.World);
            moved += switchSpeed * Time.deltaTime;

        }


        if (field == 1)
        {
            gameUI.SetActive(true);
            baseUI.SetActive(false);
        }
        else if (field == -1)
        {
            gameUI.SetActive(false);
            baseUI.SetActive(true);
        }




        Vector3 pos = transform.position;

        if (Input.GetKey("w"))
        {
            pos.y -= ySpeed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            pos.y += ySpeed * Time.deltaTime;  
        }
        if (Input.GetKey("a"))
        {
            circlePos -= circleIncrement;
            transform.Rotate(Vector3.up * rotator, Space.World);
        }
        if (Input.GetKey("d"))
        {
            circlePos += circleIncrement;
            transform.Rotate(Vector3.down * rotator, Space.World);
        }


        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.x = center_pos.x + Mathf.Cos(circlePos) * width;
        pos.z = center_pos.z + Mathf.Sin(circlePos) * width;

        transform.position = pos;

    }


}

