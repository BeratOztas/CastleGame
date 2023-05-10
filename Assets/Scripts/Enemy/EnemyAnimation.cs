using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyAnimation : MonoBehaviour
    {
        [SerializeField] private Animator enemyAnim;

        public void Run(bool run)
        {
            enemyAnim.SetBool("Run", run);
        }
        public void Attack()
        {
            enemyAnim.SetTrigger("Attack");
        }
        public void Death()
        {
            enemyAnim.SetTrigger("Death");
        }

    }
}