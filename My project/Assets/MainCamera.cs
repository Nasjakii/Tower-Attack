using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public float panSpeed = 30f;
    public float panBorderThickness = 20f;

    private bool doMovement = true;
    public float ySpeed = 10f;
    public float minY = 10f;
    public float maxY = 80f;

    public float width = 30f;

    private float circlePos = 0f;
    private float circleIncrement = 1f;

    private float rotator = 35f;



    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
            doMovement = !doMovement;

        if (!doMovement)
            return;

        //get position of the middle of the board
        Vector3 pos = GameObject.Find("FieldCenter").transform.position;

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            pos.y -= ySpeed * Time.deltaTime;
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            pos.y += ySpeed * Time.deltaTime;  
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            circlePos -= circleIncrement * Time.deltaTime;
            transform.Rotate(Vector3.up * rotator * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            circlePos += circleIncrement * Time.deltaTime;
            transform.Rotate(Vector3.down * rotator * Time.deltaTime, Space.World);
        }

        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.x = Mathf.Cos(circlePos) * width;
        pos.z = Mathf.Sin(circlePos) * width;


        transform.position = pos;

    }
}

