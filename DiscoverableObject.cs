using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoverableObject : MonoBehaviour
{
    public static Transform player;
    public string key;
    public static Dictionary<string, bool> discoverable = new Dictionary<string, bool>();
    bool discovered = false;
    bool isVisible = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < 15 && !discovered)
        {
            discovered = true;
            WorldToScreenUI.setPosition(key, transform.position);
        }


        if (discovered && isVisible) WorldToScreenUI.setPosition(key, transform.position); else if (discovered && !isVisible) { WorldToScreenUI.setPosition(key, Vector3.left * 9999f); isVisible = false;  discovered = false;  }
        addDiscovery(key, discovered);
    }

    public static void addDiscovery(string key, bool value)
    {
        if (!discoverable.ContainsKey(key)) { discoverable.Add(key, value); return; }
        discoverable[key] = value;
    }

    private void OnBecameVisible()
    {
        isVisible = true;
    }

    private void OnBecameInvisible()
    {
        if (Vector3.Distance(player.position, transform.position) < 19)
        isVisible = false;
    }


}
