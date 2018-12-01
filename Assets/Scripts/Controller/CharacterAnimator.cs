//SCRIPT POUR CONTROLLER L'ANIMATOR DU PERSONNAGE
// Version 1.0 par Nguyen Hoai Nguyen le 14 octobre

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace ConqueteRoyale
{
    public class CharacterAnimator : MonoBehaviour
    {
        const float locomationAnimationSmoothTime = 0.1f;

        NavMeshAgent agent;
        Animator animator;

        // Use this for initializationS
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            //Convertir la vitesse du Agent en pourcentage
            float speedPercent = agent.velocity.magnitude / agent.speed;

            //Faire passer la vitesse en pourcentage sur l'Animator du personnage
            animator.SetFloat("speedPercent", speedPercent, locomationAnimationSmoothTime, Time.deltaTime);
        }
    }
}
