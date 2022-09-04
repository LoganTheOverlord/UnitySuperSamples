using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefsPlaceholder : MonoBehaviour
{
    public string key;
    public string format = "%var% key";
    Text _p;
    TMPro.TMP_Text _w;

    private void Start()
    {
        _p = GetComponent<Text>() ?? null; 
        _w = GetComponent<TMPro.TMP_Text>() ?? null;
    }

    // Update is called once per frame
    void Update()
    {
        string _f = format;
        bool isString = PlayerPrefs.GetInt(key,-int.maxValue) <= int.maxValue;
        if (!_w && _p)
        {
            if (isString) _p.text = _f.Replace("%var%", PlayerPrefs.GetString(key));
            else
                _p.text = _f.Replace("%var%", $"{PlayerPrefs.GetInt(key, 0)}");
        } else
        {
            if (isString) _w.text = _f.Replace("%var%", PlayerPrefs.GetString(key));
            else
                _w.text = _f.Replace("%var%", $"{PlayerPrefs.GetInt(key, 0)}");
        }
    }
}
