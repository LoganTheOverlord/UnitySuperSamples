using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Picker : MonoBehaviour
{
    public Text pickupText;
    public GameObject toPick = null;
    public bool isTriggered = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isTriggered && toPick)
        {
            pickupText.text = $"Press [F] to pickup a {toPick.name}";

            if (Input.GetKeyDown(KeyCode.F))
            {
                AudioSource.PlayClipAtPoint(Resources.Load<AudioClip>("pickup_generic"), toPick.transform.position);
                Destroy(toPick);
                toPick = null;
            }
        } else
        {
            pickupText.text = "";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Pickup") return;
        isTriggered = false;
        toPick = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Pickup") return;
        isTriggered = true;
        toPick = other.gameObject;
    }
}
