using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Enemy;

namespace Player
{
    public class PlayerManagement : MonoBehaviour
    {
        
        private NavMeshSurface navMeshSurface;
        private int _level;
        public Action<int, int> OnLevelChanged;
        private GameObject blueGate;
        private GameObject redGate;
        [SerializeField] private GameObject player;
        private bool canWalk = true;
        [SerializeField] private PlayerMovement playerMovement;
        private EnemyController[] enemyControllers;
        
        private bool levelFinished;
        public bool LevelFinished { get; set; }

        private void Awake()
        {
            Level = 1;
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
                OnLevelChanged?.Invoke(oldLevel, _level); //if (OnLevelChanged != null)
                                                          //    OnLevelChanged.Invoke(oldLevel,_level);
            }
        }
        public void Init()
        {
            navMeshSurface = FindObjectOfType<NavMeshSurface>();
            navMeshSurface.BuildNavMesh();
        }
        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && canWalk)
            {

                playerMovement.Running = true;
                levelFinished = false;
                canWalk = false;
            }
        }
        public void SetCanWalk(bool value)
        {
            canWalk = value;
        }
        public bool GetCanWalk()
        {
            return canWalk;
        }
        public void OpenGate(Key key) {
            blueGate = GameObject.FindGameObjectWithTag("BlueGate");
            redGate = GameObject.FindGameObjectWithTag("RedGate");
            if (key == Key.Blue) {
                blueGate.GetComponent<BoxCollider>().isTrigger = true;
            }
            else {
                redGate.GetComponent<BoxCollider>().isTrigger = true;
            }
        }


        public void FinishLevel() {
            StartCoroutine(NextLevel(1f));
        }
        IEnumerator NextLevel(float time) {
            yield return new WaitForSeconds(time);
            playerMovement.Running = false;
            this.LevelFinished = true;
            SetCanWalk(false);
            UIManager.Instance.NextLvlUI();
        }
        public void LevelFailed() {
            playerMovement.Running = false;
            UIManager.Instance.RestartButtonUI();
        }
        public void CharacterReset()
        {
            this.LevelFinished = false;
            gameObject.SetActive(false);
            player.transform.localRotation = Quaternion.Euler(0, 0f, 0);
            player.transform.position = new Vector3(0f, 0f, 0f);
            gameObject.SetActive(true);
            Level = 1;
            UIManager.Instance.TapToPlay();
            enemyControllers = FindObjectsOfType<EnemyController>();
            foreach(var enemy in enemyControllers) {
                enemy.IsEnemyAttacked = false;
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
            var hittables = collider.GetComponents<IHittable>();
            if (hittables == null)
                return;
            foreach(var hittable in hittables) {
                hittable.OnHit(this);
            }
        }
    }
}