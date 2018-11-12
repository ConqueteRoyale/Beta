using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FieldOfView : MonoBehaviour {

    public Animator anim;
    public GameObject unit;
    public float speed = 8f;

    public float viewRadius;
    public float viewRadiusAttack;

    [Range(0, 360)]
    public float viewAngle;

    [Range(0, 360)]
    public float viewAngleAura;


    public LayerMask targetMask;
    public LayerMask obstacleMask;

    [HideInInspector]
    public List<Transform> visibleTargets = new List<Transform>();
    public List<Transform> visibleTargetsAura = new List<Transform>();

    public List<Transform> targets;
    public List<Transform> targetsAura;

    public bool isLockOn = false;
    public bool isNearMe = false;

    public NavMeshAgent agentNav;

    public int index = 1;



    public float speedTarget = 1f;
    public Vector3 speedRot = Vector3.right * 50f;




    void Start()
    {
        StartCoroutine("FindTargetsWithDelay", 0.2f);
        targets = new List<Transform>();
    }

    IEnumerator FindTargetsWithDelay(float delay)
    {
        while(true)
        {
            yield return new WaitForSeconds(delay);
            FindTargetsNearMe();
            FindVisibleTargets();
        }
    }

    void FindVisibleTargets()
    {
        visibleTargets.Clear();
        targets.Clear();
        isLockOn = false;
        index = 1;
        if (isLockOn == false)
            anim.SetFloat("canAttack", 0f);


        //Collider[] targetNear = Physics.OverlapSphere(transform.position, viewRadiusAttack, targetMask);

        Collider[] targetsInviewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

        //Rechercher tout les targets dans la zone de vue
        for (int i = 0; i < targetsInviewRadius.Length; i++)
        {
            Transform target = targetsInviewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;

            //Verifier s'il y a un ennemi dans l'angle de vue du personnage
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector3.Distance(transform.position, target.position);

                //Verifier s'il y a un obstacle entre le personnage et l'ennemi
                if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
                {
                    visibleTargets.Add(target);
                    
                    if (visibleTargets.Count > 0)
                    {
                        if (targets.Count.Equals(0))
                        {
                            AddAllEnemies();
                            isLockOn = true;
                        }
                    }

                    if(isLockOn == true)
                        anim.SetFloat("canAttack", 1f);
                }

            }
        }
    }

    public void FindTargetsNearMe()
    {
        visibleTargetsAura.Clear();
        targetsAura.Clear();
        isNearMe = false;
        index = 2;

        Collider[] targetNear = Physics.OverlapSphere(transform.position, viewRadiusAttack, targetMask);

        for (int i = 0; i < targetNear.Length; i++)
        {
            Transform targetAura = targetNear[i].transform;
            Vector3 dirToTarget = (targetAura.position - transform.position).normalized;

            if(Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                AddAllEnemies();
                isNearMe = true;
            }
        }
    }

    public void Update()
    {
        if(isLockOn == true)
        {
            Quaternion targetRotation = Quaternion.LookRotation(targets[0].transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
        }

        if (isNearMe == true && isLockOn == false)
        {   
            agentNav.ResetPath();
            agentNav.SetDestination(targetsAura[0].transform.position);
            isNearMe = false;
        }
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if(!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }

        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));

    }

    public void AddAllEnemies()
    {
        GameObject[] go = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in go)
            AddTarget(enemy.transform);
    }

    public void AddTarget(Transform enemy)
    {
        switch (index)
        {
            case 1:
                targets.Add(enemy);
                break;
            case 2:
                targetsAura.Add(enemy);
                break;
            default:
                break;
        }
        targets.Add(enemy);
    }
}
