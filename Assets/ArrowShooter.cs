using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShooter : MonoBehaviour {

    public GameObject arrowPrefab;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.K))
        {
            GameObject newArrow = Instantiate(arrowPrefab) as GameObject;
            newArrow.transform.position = transform.position;
            Rigidbody rb = newArrow.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * 30;
        }
	}
}
