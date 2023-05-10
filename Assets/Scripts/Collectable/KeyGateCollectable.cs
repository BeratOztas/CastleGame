using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Key
{
    Red,
    Blue
}
public class KeyGateCollectable : MonoBehaviour, ICollectable
{
    
    public Key key;

    public void OnCollect(PlayerManagement playerManagement)
    {
        playerManagement.OpenGate(key);
        gameObject.SetActive(false);
    }
}
