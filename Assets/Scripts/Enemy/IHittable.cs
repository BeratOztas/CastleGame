using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public interface IHittable 
{
    public void OnHit(PlayerManagement playerManagement);
}
