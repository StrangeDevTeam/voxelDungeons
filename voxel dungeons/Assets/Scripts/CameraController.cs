using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject cameraTarget; //This is the target that the camera will rotate and move around
    public float rotationSpeed = 1.0f; //Used to controll the speed of camera rotaion on the arrow keys

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))                                         //
            cameraTarget.transform.Rotate(new Vector3(0.0f, rotationSpeed, 0.0f));   // Rotate the camera target
        if (Input.GetKey(KeyCode.RightArrow))                                        // based on arrow keys
            cameraTarget.transform.Rotate(new Vector3(0.0f, -rotationSpeed, 0.0f));  //
        if (Input.GetKey(KeyCode.UpArrow))                                           // Camera is a child of cameraTarget
            cameraTarget.transform.Rotate(new Vector3(rotationSpeed, 0.0f, 0.0f));   // so doing this rotates the camera around the camera Target
        if (Input.GetKey(KeyCode.DownArrow))                                         //
            cameraTarget.transform.Rotate(new Vector3(-rotationSpeed, 0.0f, 0.0f));  //

    }
}
