using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGateCollectable : MonoBehaviour, ICollectable
{
    public void OnCollect(PlayerManagement playerManagement)
    {
        playerManagement.FinishLevel();
    }
}
