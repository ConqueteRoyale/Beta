using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHook : MonoBehaviour {

    public GameObject damageCollider;

    public void OpenDamageColliders()
    {
        damageCollider.SetActive(true);
    }

    public void CloseDamageColliders()
    {
        damageCollider.SetActive(false);
    }
}
