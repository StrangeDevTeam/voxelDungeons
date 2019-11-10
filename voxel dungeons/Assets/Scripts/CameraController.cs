using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    /*  camera orbit code taken from:
     *  https://wiki.unity3d.com/index.php/MouseOrbitImproved#Code_C.23
     */
    

    public Transform target; // the object/entity the camera will orbit around
    public float distance = 5.0f; //the default/starting orbital distance from the target
    public float xSpeed = 180.0f; //sensitivity on x axis, default 120
    public float ySpeed = 180.0f; //sensitivity on y axis, default 120

    public float yMinLimit = -10f; // the lower camera angle limit to stop camera from clipping through the ground as much
    public float yMaxLimit = 80f; // the upper camera angle limit to stop camera looping round and becoming inverted

    public float distanceMin = 3f; // the minimum distance the camera can zoom in to view the character
    public float distanceMax = 15f; // the maximum distrance the camera may zoom out from the character

    private Rigidbody rigidbody; // declared in Start()

    float x = 0.0f; // the coordinates of the camera
    float y = 0.0f; //

    // Use this for initialization
    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        rigidbody = GetComponent<Rigidbody>();

        
        if (rigidbody != null)               //
        {                                    // Make the rigid body not change rotation
            rigidbody.freezeRotation = true; //
        }                                    //
    }

    void LateUpdate()
    {
        if (target)
        {
            if (!UIController.isCursorVisible)                     // if the player isnt navvigating through menus
            {                                                      //
                x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;    //take mouse inputs
                y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;    //
            }

            y = ClampAngle(y, yMinLimit, yMaxLimit);           // stop camera from going outside the limits

            Quaternion rotation = Quaternion.Euler(y, x, 0);                                                      // Important Maths
            distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax);  // No touch!

            RaycastHit hit;                                                     // if the camera's line of sight to the player is broken
            if (Physics.Linecast(target.position, transform.position, out hit)) // or if the camera hits a wall, the camera will not clip 
            {                                                                   //
                if(hit.collider.gameObject.name != "Player")                    // and instead will jump forward until the player can be seen
                {                                                               // this should stop camera clipping through terrain
                                                                                // provided that the gameobject blocking line of sight isnt
                    distance = hit.distance;                                    // the player itself
                }                                                               //
            }                                                                   

            Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
            Vector3 position = rotation * negDistance + target.position;

            transform.rotation = rotation;
            transform.position = position;
        }
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)                       //
            angle += 360F;                       // stops camera amgle from shifting outside
        if (angle > 360F)                        // of min and max bounds
            angle -= 360F;                       //
        return Mathf.Clamp(angle, min, max);     //
    }
}

