using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfController : MonoBehaviour
{
    Camera main;
    public float rot;
    public float yrot;
    // Start is called before the first frame update
    // Let's find our camera, and assign it. This way, we save little CPU power, because Camera.main is static refernce, which.. try someday to debug
    // performance and see, if you see "findMainCamera" there. Hereby, we fix this by assigning direct reference to it, saving some resources.
    void Start()
    {
        main = Camera.main;
    }

    // Update is called once per frame
    // You could do this in fixed update, but it won't work properly due to input checking, which happens directly in given frame
    // Update function is run every frame game renders, thus, you should not put game-reliant functions in update, but in fixed update.
    void Update()
    {
        if (Input.GetMouseButton(0)) //is mouse down? (left mouse button)
        {
            rot += Input.GetAxis("Mouse X") != 0 ? Input.GetAxis("Mouse X") * 5f : 0; //we add mouse x axis, the movements on horizontal axis
            yrot -= Input.GetAxis("Mouse Y") != 0 ? Input.GetAxis("Mouse Y") * 5f : 0; //we add mouse y axis, ie. movements on vertical axis
            yrot = Mathf.Clamp(yrot, 10, 90); //we don't want camera to get under or over your object
        }

        //here we fix the issue with continuity of rotation, nothing complicated, really.
        rot = rot >= 360 ? 0 : rot;
        rot = rot <= -360 ? 0 : rot;

        main.transform.position = transform.position; //we set the camera position to be at center of our object
        main.transform.rotation = Quaternion.Euler(new Vector3(yrot, rot, 0)); //we're setting angles for camera
        main.transform.position += main.transform.forward * -10f; //finally, we add some distance between camera and object
    }
}
