using System;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MainCamera : MonoBehaviour
{

    public float ySpeed = 10f;
    private float minY = 10f;
    private float maxY = 80f;

    public float rotate_speed = 1;

    private float width = 30f;

    private float circlePos = 0f;
    private float circleIncrement = 0.001f;

    private float rotator = 360f / (2 * Mathf.PI) * 0.001f;

    private bool game_field = true;
    public float timeToSwap = 3f;
    private float switching = 0f;

    public Transform fieldCenter;
    private Vector3 center_pos;

    private UIManager uimanager;

    private void Start()
    {
        circleIncrement = circleIncrement * rotate_speed;
        rotator = rotator * rotate_speed;
        uimanager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();

        center_pos = fieldCenter.position;
    }

    void Update()
    {

        if (switching > 0f) switching -= Time.deltaTime;
        if (Input.GetKeyUp("tab") && switching <= 0f)
        {
            SwitchField();
        } 

        CameraMovement();
  

    }

    private void SwitchField()
    {
        game_field = !game_field;

        if (game_field)
        {
            uimanager.SetActiveScreen(0, true);
            uimanager.SetActiveScreen(1, false);
        } else
        {
            uimanager.SetActiveScreen(1, true);
            uimanager.SetActiveScreen(0, false);

        }

        Vector3 endpos = new Vector3(0, 0, 200);
        if (game_field) StartCoroutine(timeToSwap.Tweeng((p) => fieldCenter.position = p, fieldCenter.position, fieldCenter.position + endpos));
        if (!game_field) StartCoroutine(timeToSwap.Tweeng((p) => fieldCenter.position = p, fieldCenter.position, fieldCenter.position - endpos));

        switching = timeToSwap;
    }

    private void CameraMovement()
    {
        
        Vector3 pos = transform.localPosition;

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
        pos.x = center_pos.x + 20 + Mathf.Cos(circlePos) * width;
        pos.z = center_pos.z - 20 + Mathf.Sin(circlePos) * width;

        transform.localPosition = pos;
    }

}

