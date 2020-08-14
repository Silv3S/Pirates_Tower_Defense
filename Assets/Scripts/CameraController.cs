using UnityEngine;
using System.Collections;
 
 public class CameraController : MonoBehaviour
{ 
    [SerializeField]
    float zoomSpeed = 0.3f;

    private float yaw = -90f;
    private float pitch = 70f;

    void Update()
    {
        //Look around with Right Mouse
        if (Input.GetMouseButton(1))
        {
            yaw +=  Input.GetAxis("Mouse X");
            pitch -=  Input.GetAxis("Mouse Y");

            transform.eulerAngles = new Vector3(pitch, yaw, 0f);
        }

        //Zoom in and out with Mouse Wheel
        transform.Translate(0, 0, Input.GetAxis("Vertical") * zoomSpeed, Space.Self);
        transform.Translate(Input.GetAxis("Horizontal") * zoomSpeed,0,0, Space.Self);
    }
}