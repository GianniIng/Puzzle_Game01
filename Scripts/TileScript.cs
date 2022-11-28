using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    public Vector3 targetPosition;

    void Start()
    {
        targetPosition = transform.position;
    }

    
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, 0.05f);
    }
}
