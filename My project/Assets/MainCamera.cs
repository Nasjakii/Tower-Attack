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
    private float circleIncrement = 0.001f;

    private float rotator = 360f / (2 * Mathf.PI) * 0.001f;



    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
            doMovement = !doMovement;

        if (!doMovement)
            return;

        //get position of the middle of the board
        Vector3 center_pos = GameObject.Find("FieldCenter").transform.position;
        Vector3 pos = transform.position;

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
            circlePos -= circleIncrement;
            transform.Rotate(Vector3.up * rotator, Space.World);
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            circlePos += circleIncrement;
            transform.Rotate(Vector3.down * rotator, Space.World);
        }


        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.x = center_pos.x + Mathf.Cos(circlePos) * width;
        pos.z = center_pos.z + Mathf.Sin(circlePos) * width;

        Debug.Log(circlePos);

        transform.position = pos;

    }
}

