using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    bool active;
    Canvas canvas;
    bool cursoractive;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            cursoractive = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            active = !active;
            canvas.enabled = active;
            Time.timeScale = (active) ? 0 : 1f;
        }
        if (Input.GetKeyDown("escape") && cursoractive == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            cursoractive = false; 
        }
    }
}
