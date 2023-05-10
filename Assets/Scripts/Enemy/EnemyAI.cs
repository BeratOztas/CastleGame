using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField] private EnemyAnimation enemyAnim;
        [SerializeField] private NavMeshAgent enemyAgent;
        [SerializeField] private Transform[] navMeshPoints;
        private int destinationIndex;

        private void Start()
        {
            destinationIndex = 0;
            enemyAgent.SetDestination(navMeshPoints[destinationIndex].position);
        }

        private void Update()
        {
            AnimateEnemy();
            CheckIfEnemyReachedPoint();
        }

        private void AnimateEnemy()
        {
            if (enemyAgent.velocity.magnitude > 0)
            {
                enemyAnim.Run(true);
            }
            else
                enemyAnim.Run(false);
        }

        private void CheckIfEnemyReachedPoint()
        {
            if (!enemyAgent.pathPending)
            {
                if (enemyAgent.remainingDistance <= enemyAgent.stoppingDistance)
                {
                    if (!enemyAgent.hasPath || enemyAgent.velocity.sqrMagnitude == 0f)
                    {
                            SetNewDestination();
                    }
                }
            }
        }

        private void SetNewDestination()
        {
            if (destinationIndex == navMeshPoints.Length-1) { 
                destinationIndex=0;
            }
            else {
                destinationIndex++;
            }
            enemyAgent.SetDestination(navMeshPoints[destinationIndex].position);
        }
    }
}