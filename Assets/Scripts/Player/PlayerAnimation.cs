using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Animator playerAnim;
       
        public void Run(bool run ) {
            playerAnim.SetBool("Run", run);
        }
        public void Attack() {
            playerAnim.SetTrigger("Attack");
        }
    }
}