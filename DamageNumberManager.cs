using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageNumberManager : MonoBehaviour
{
    public static DamageNumberManager instance;
    public GameObject prefab;

    public static Dictionary<Text,GameObject> nums = new Dictionary<Text,GameObject>();
    public static void addNumber(int number, GameObject parent, Color _c)
    {
        GameObject _p = Instantiate(instance.prefab, DamageNumberManager.instance.transform);
        Text _t = _p.GetComponent<Text>();
        _t.text = number.ToString();
        _t.GetComponent<Text>().material = Instantiate(_t.material);
        _t.material.color = _c;

        Vector2 _v = Camera.main.WorldToScreenPoint(parent.transform.position);

        _v = new Vector2(_v.x, _v.y);

        _p.GetComponent<RectTransform>().SetPositionAndRotation(_v, Quaternion.identity);
        nums.Add(_t, parent.gameObject);

        print($"DAMAGE! {_v.x}");
    }
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (Text _p in nums.Keys)
        {
            if (_p == null) continue;
            if (nums[_p] == null) { Destroy(_p); continue; };
            if (nums[_p].transform == null) { Destroy(_p); continue; };
            Color c = _p.material.color;
            c.a -= 0.0295f;
            _p.material.color = c;

            Vector3 _v = Camera.main.WorldToScreenPoint(nums[_p].transform.position);
            _v += Vector3.up * 100 * (2 - c.a);

            _v = new Vector3(_v.x, _v.y, 0);
            RectTransform _r = _p.GetComponent<RectTransform>();
            _r.SetPositionAndRotation(_v, Quaternion.identity);

            _r.GetComponent<RectTransform>().localScale *= 1.054f;

            if (c.a <=0)
            {
                Destroy(_p.transform.gameObject);
            }
        }
        
    }
}
