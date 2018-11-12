// SCRIPT DE DÉPLACEMENT D'UNITÉ POUR TEST ANIMATION (MECANIM)
// Version 2.0 par Ulysse le 15 octobre

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

    NavMeshAgent agentNav;
    public bool DeplacementFlag = false;
    public GameObject unit;
    public bool selected = false;
    


    // Use this for initialization
    void Start() {

        agentNav = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update() {
        //Debug.Log(Mathf.Abs(agentNav.velocity.sqrMagnitude));

        // test pour l'instant, voir readme
        CmdDeplacementUnite();
    }

    [Command]
    public void CmdDeplacementUnite(){


        if(hasAuthority == false){

            return;

        }
        if (unit == null)
        {
            return;
        }
            RaycastHit hit;

        if (Input.GetMouseButtonDown(1) && unit.tag == "Friendly")
        {

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                agentNav.SetDestination(hit.point);
            }

         
            if (!agentNav.pathPending)
            {
                if(Mathf.Abs(agentNav.velocity.sqrMagnitude) < 0.8f)
                {
                    CmdArreterUnite();
                }


                if (agentNav.remainingDistance <= agentNav.stoppingDistance)
                {

                    if (!agentNav.hasPath || Mathf.Abs(agentNav.velocity.sqrMagnitude) < float.Epsilon)
                    {

                        CmdArreterUnite();
                    }
                }
            }
        }
    }

    [Command]
    public void CmdArreterUnite(){
        agentNav.isStopped = true;
    } 
}
