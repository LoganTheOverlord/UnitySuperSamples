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
            if (Input.GetAxis("Mouse X") != 0)
            {
                rot += Input.GetAxis("Mouse X") * 5f;
                rot = Mathf.Clamp(rot, -360, 360);
            }

            if (Input.GetAxis("Mouse Y") != 0)
            {
                yrot -= Input.GetAxis("Mouse Y") * 5f;
                yrot = Mathf.Clamp(yrot, 10, 90);
            }
        }

        rot = rot >= 360 ? 0 : rot;
        rot = rot <= -360 ? 0 : rot;

        main.transform.position = this.transform.position;
        main.transform.LookAt(transform);
        main.transform.rotation = Quaternion.Euler(new Vector3(yrot, rot, 0));
        main.transform.position += main.transform.forward * -10f;
    }
}
