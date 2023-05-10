using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;

namespace Player
{
    public class PlayerAnimation : MonoSingleton<PlayerAnimation>
    {
        [SerializeField] private Animator playerAnim;
       
        public void Run(bool run ) {
            playerAnim.SetBool("Run", run);
        }
        public void Attack() {
            playerAnim.SetTrigger("Attack");
        }
        public void Death() {
            playerAnim.SetTrigger("Death");
        }
    }
}