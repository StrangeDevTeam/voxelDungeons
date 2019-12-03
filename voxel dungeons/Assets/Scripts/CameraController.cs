﻿using UnityEngine;

public class CameraController : MonoBehaviour
{
    /*  camera orbit code taken from:
     *  https://wiki.unity3d.com/index.php/MouseOrbitImproved#Code_C.23
     */
    

    public Transform target; // the object/entity the camera will orbit around, assigned in inspector
    public float distance = 5.0f; //the default/starting orbital distance from the target
    public float xSpeed = 180.0f; //sensitivity on x axis, default 180
    public float ySpeed = 180.0f; //sensitivity on y axis, default 180

    public float yMinLimit = -10f; // the lower camera angle limit to stop camera from clipping through the ground as much
    public float yMaxLimit = 80f; // the upper camera angle limit to stop camera looping round and becoming inverted

    public float distanceMin = 3f; // the minimum distance the camera can zoom in to view the character
    public float distanceMax = 15f; // the maximum distrance the camera may zoom out from the character

    new private Rigidbody rigidbody; // declared in Start()

    //co-ordinates of the camera
    float x = 0.0f;
    float y = 0.0f;
    

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        rigidbody = GetComponent<Rigidbody>();

        //remove all rotation physics from camera
        if (rigidbody != null)              
        {                                   
            rigidbody.freezeRotation = true;
        }                                   
    }

    void LateUpdate()
    {
        if (target)
        {
            //if user isnt navigating menus, use mouse inputs to rotate camera
            if (!UIController.isCursorVisible)                 
            {                                                  
                x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
                y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
            }

            // stop camera from going outside the limits
            y = ClampAngle(y, yMinLimit, yMaxLimit);

            //Important Maths... No Touch!
            Quaternion rotation = Quaternion.Euler(y, x, 0);                                                      
            distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax);  

            //camera jumps forward when line of sight is broken so the camera doesnt clip through objects (as much)
            RaycastHit hit;                                                     
            if (Physics.Linecast(target.position, transform.position, out hit)) 
            {                                                                   
                if(hit.collider.gameObject.name != "Player")                    
                {                                                               
                                                                                
                    distance = hit.distance;                                    
                }                                                               
            }                                                                   

            Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
            Vector3 position = rotation * negDistance + target.position;

            //move the camera
            transform.rotation = rotation;
            transform.position = position;
        }
    }

    //stops camera angle from shifting outside the Min and Max bounds
    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)                       
            angle += 360F;                       
        if (angle > 360F)                        
            angle -= 360F;                       
        return Mathf.Clamp(angle, min, max);     
    }
}

