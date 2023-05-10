using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;
using System;

namespace Enemy
{
    public class EnemyController : MonoBehaviour, IHittable
    {
        [SerializeField] private int enemyLevel;
        [SerializeField] private EnemyAnimation enemyAnim;
        [SerializeField] private LevelView enemyLevelView;
        [SerializeField] private FieldOfView fov;
        private PlayerManagement playerManagement;
        Color newColor;
        private bool isEnemyAttacked;

        public bool IsEnemyAttacked { get { return isEnemyAttacked; }set { isEnemyAttacked = value; } }
        
        private void Start()
        {
            isEnemyAttacked = false;
            playerManagement = FindObjectOfType<PlayerManagement>();
            newColor = Color.green;
            enemyLevelView.UpdateLevel(enemyLevel);
        }
        private void Update()
        {
            CheckPlayer();
        }

        private void CheckPlayer()
        {
            if(playerManagement.Level>=enemyLevel) {
                enemyLevelView.UpdateColor(newColor);
            }
            if (fov.canSeePlayer && enemyLevel > playerManagement.Level&& !isEnemyAttacked)
            {
                StartCoroutine(KillPlayer(1f));
            }
        }

        public void OnHit(PlayerManagement playerManagement)
        {

            if (playerManagement.Level > enemyLevel)
            {
                StartCoroutine(Death(2f));
            }
            else if (playerManagement.Level == enemyLevel)
            {
                StartCoroutine(Death(2f));
            }
            else
            {
                StartCoroutine(KillPlayer(1f));
            }
        }
        IEnumerator Death(float enemyDeathTime)
        {
            PlayerAnimation.Instance.Attack();
            enemyAnim.Death();
            yield return new WaitForSeconds(enemyDeathTime);
            gameObject.SetActive(false);
        }
        IEnumerator KillPlayer(float waitingTime) {
            PlayerAnimation.Instance.Death();
            enemyAnim.Attack();
            isEnemyAttacked = true;
            yield return new WaitForSeconds(waitingTime);
            playerManagement.LevelFailed();
        }




    }
}