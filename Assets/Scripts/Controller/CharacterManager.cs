using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour {

    public Animator anim;
    public GameObject unit;

    public float health = 3;
    public float amount = 1;
    public bool isDead = false;
    

    // Use this for initialization
    void Start () {

	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DamageCollider"))
        {
            Debug.Log("HIT");
            health -= amount;

            if (health < 0)
                health = 0;

            if (health <= 0)
            {
                if (!isDead)
                {
                    VariablesGlobales.effectifTotal_joueur_01--;

                    anim.SetTrigger("death");
                    isDead = true;

                    Destroy(unit, 1.2f);
                }
            }
        }
    }

}
