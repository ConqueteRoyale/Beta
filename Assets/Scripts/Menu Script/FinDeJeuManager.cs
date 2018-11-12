using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinDeJeuManager : MonoBehaviour {

    public Transform orText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        orText.GetComponent<Text>().text = VariablesGlobales.banqueOr_joueur_01.ToString();
	}
}
