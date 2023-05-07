using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseCollectable : MonoBehaviour, ICollectable
{
    [SerializeField] private int LevelAmount;
    public void OnCollect(PlayerManagement playerManagement)
    {
        playerManagement.Level += LevelAmount;
        gameObject.SetActive(false);
    }
}
