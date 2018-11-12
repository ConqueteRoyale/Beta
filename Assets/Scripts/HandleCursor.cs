using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleCursor : MonoBehaviour {

    public Texture2D mouse;
    public Texture2D attack;
    public Texture2D ally;

    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public static HandleCursor Instance
    {
        get; private set;
    }

    void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity)) 
        {
            if (hitInfo.collider.gameObject.layer == LayerMask.NameToLayer("Target"))
            {
                
                setAttack();
            }

            if (hitInfo.collider.gameObject.layer == LayerMask.NameToLayer("Allies"))
            {
                setAlly();
            }

            else if (hitInfo.collider.gameObject.layer == LayerMask.NameToLayer("Unit"))
            {
                setAlly();
            }

            else
            {
                setMouse();
            }
        }
	}

    public void setMouse()
    {
        Cursor.SetCursor(mouse, hotSpot, cursorMode);
    }

    public void setAttack()
    {
        Cursor.SetCursor(attack, hotSpot, cursorMode);
    }

    public void setAlly()
    {
        Cursor.SetCursor(ally, hotSpot, cursorMode);
    }
}
