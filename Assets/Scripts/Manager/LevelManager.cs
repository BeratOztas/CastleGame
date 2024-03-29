using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class LevelManager : GenericSingleton<LevelManager>
{

    [SerializeField] private GameObject[] levelPrefabs;
    [SerializeField] private int levelIndex = 0;
    [SerializeField] private bool forceLevel = false;

    private PlayerManagement playerManagement;
    private int globalLevelIndex = 0;
    private bool inited = false;
    private GameObject currentLevel;


    private void Awake()
    {
        Init();
        GenerateCurrentLevel();
        playerManagement.Init();
    }
   

    public void Init()
    {
        if (inited)
        {
            return;
        }
        inited = true;
        PlayerPrefs.DeleteAll();
        globalLevelIndex = PlayerPrefs.GetInt("Level", 0);

        if (forceLevel)
        {
            globalLevelIndex = levelIndex;
            return;
        }
        levelIndex = globalLevelIndex;

        if (levelIndex >= levelPrefabs.Length)
        {
            //  levelIndex= GameUtility.RandomIntExcept(_levelPrefabs.Length, _levelIndex, 0);
            levelIndex = 0;
            globalLevelIndex = 0;
            PlayerPrefs.SetInt("Level", globalLevelIndex);
        }

    }//init

    public void GenerateCurrentLevel()
    {

        if (currentLevel != null)
        {
            Destroy(currentLevel);
        }
        currentLevel = Instantiate(levelPrefabs[levelIndex]);
        playerManagement = FindObjectOfType<PlayerManagement>();
        playerManagement.Init();

    }

    public GameObject GetCurrentLevel()
    {
        return currentLevel;
    }

    public void LevelUp()
    {
        if (forceLevel)
        {
            return;
        }
        globalLevelIndex++;
        PlayerPrefs.SetInt("Level", globalLevelIndex);
        levelIndex = globalLevelIndex;

        if (levelIndex >= levelPrefabs.Length)
        {
            levelIndex = 0;
            globalLevelIndex = 0;
            PlayerPrefs.SetInt("Level", globalLevelIndex);
        }

    }
    public int GetGlobalLevelIndex()
    {
        return globalLevelIndex;
    }



}
