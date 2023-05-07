using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableRotate : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.1f;
    private float angle;
  
    void Update()
    {
        
            angle = (angle + speed) % 360f;
            transform.localRotation = Quaternion.Euler(new Vector3(0f, angle, 0f));
      
    }
}
