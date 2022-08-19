using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Visyde;

public class Crosshair : MonoBehaviour
{
    public static bool canBeRendered = true;
    // Start is called before the first frame update
    void Start()
    {
        canBeRendered = true;
    }

    // Update is called once per frame
    void Update()
    {
        hide();
        if (!canBeRendered) return;
        transform.position = Input.mousePosition;
        Cursor.visible = false;
        if (GameManager.instance.isGameOver) Destroy(gameObject);
        if (GameManager.isDraw) Destroy(gameObject);

    }

    private void Awake()
    {
    }

    void hide()
    {
        if (canBeRendered) transform.localScale = Vector3.one; else transform.localScale = Vector3.zero;
    }
}
