using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressFiller : MonoBehaviour
{
    public string key, maxkey;
    public Image filler;
    void FixedUpdate()
    {
        if (filler == null || key == null || maxkey == null) return;

        int val = PlayerPrefs.GetInt(key, 0);
        int max = PlayerPrefs.GetInt(maxkey, 1);

        if (max == 0) max = 1;

        filler.fillAmount = (float)((float) val / (float)max);
    }
}
