using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;

namespace Player
{
    public class PlayerPresenter : MonoBehaviour
    {
        [SerializeField] private PlayerManagement playerManagement;
        [SerializeField] private LevelView playerLevelView;
        private void Start()
        {
            playerLevelView.UpdateLevel(playerManagement.Level);
        }

        private void OnEnable()
        {
            playerManagement.OnLevelChanged += OnLevelChanged;
           
        }
        private void OnDisable()
        {
            playerManagement.OnLevelChanged -= OnLevelChanged;
        }

        private void OnLevelChanged(int oldLevel,int newLevel) {
            playerLevelView.UpdateLevelAnimated(newLevel);
        }

    }
}