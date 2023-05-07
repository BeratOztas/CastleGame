using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerManagement : MonoBehaviour
    {
        private int _level;
        public Action<int, int> OnLevelChanged;

        private void Start()
        {
            _level = 1;
        }
        public int Level
        {
            get { return _level; }
            set
            {
                if (_level == value)
                    return;
                var oldLevel = _level;
                _level = value;
                OnLevelChanged?.Invoke(oldLevel, _level);
            }
        }

        private void OnTriggerEnter(Collider collider)
        {
            var collectables = collider.GetComponents<ICollectable>();
            if (collectables == null)
                return;
            foreach(var collectable in collectables) {
                collectable.OnCollect(this);
            }
        }
    }
}