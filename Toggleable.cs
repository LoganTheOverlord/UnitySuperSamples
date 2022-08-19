using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggleable : MonoBehaviour
{
    public KeyCode toggleKey;
    public Transform toggleTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (toggleTransform != null)
        {
            if (Input.GetKeyDown(toggleKey))
            {
                toggleTransform.gameObject.SetActive(!toggleTransform.gameObject.activeInHierarchy);
            }
        }
    }
}
