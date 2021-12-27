using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    Camera main;
    public float rot;
    public float yrot;
    // Start is called before the first frame update
    void Start()
    {
        main = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            rot += Input.GetAxis("Mouse X") != 0 ? Input.GetAxis("Mouse X") * 5f : 0; 
            yrot -= Input.GetAxis("Mouse Y") != 0 ? Input.GetAxis("Mouse Y") * 5f : 0;
            yrot = Mathf.Clamp(yrot, 10, 90);
        }

        rot = rot >= 360 ? 0 : rot;
        rot = rot <= -360 ? 0 : rot;

        main.transform.position = this.transform.position;
        main.transform.LookAt(transform);
        main.transform.rotation = Quaternion.Euler(new Vector3(yrot, rot, 0));
        main.transform.position += main.transform.forward * -10f;
    }
}
