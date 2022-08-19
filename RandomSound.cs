using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSound : MonoBehaviour
{
    public List<AudioClip> sounds = new List<AudioClip>();
    AudioSource s;
    // Start is called before the first frame update
    void Start()
    {
        s = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, 100) < 2)
        {
            s.Play();
        }
    }
}
