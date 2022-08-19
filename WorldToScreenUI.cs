using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldToScreenUI : MonoBehaviour
{
    public string key;
    public static Dictionary<string, Vector3> positions = new Dictionary<string, Vector3>();

    void Update()
    {
        if (positions.ContainsKey(key))
        {
            transform.position = Camera.main.WorldToScreenPoint(positions[key]);
        } else
        {
            transform.position = Vector3.left * 9999f;
        }
    }

    public static void setPosition(string key, Vector3 value)
    {
        if (!positions.ContainsKey(key)) { positions.Add(key, value); return; }
        positions[key] = value;
    }
}
