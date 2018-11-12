using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//2018-09-15
//Kevin Langlois
//Script qui controle les mouvements de caméras dans le menu principal

public class ControlCameraMenu : MonoBehaviour {

    public Transform positionActuelle;
    public float vitesseDeplacement;
    public Vector3 dernierePosition;

    private void Update()
    {
        gameObject.transform.position = Vector3.Lerp(transform.position, positionActuelle.position, vitesseDeplacement);
        gameObject.transform.rotation = Quaternion.Slerp(transform.rotation, positionActuelle.rotation, vitesseDeplacement);

        float velocity = Vector3.Magnitude(transform.position - dernierePosition);

        dernierePosition = transform.position;
    }

    public void ChangerPosition(Transform nouvellePosition)
    {
        positionActuelle = nouvellePosition;
    }

}
