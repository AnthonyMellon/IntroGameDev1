using System;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer :  MonoBehaviour
{
    public float timeToDestroy;

    private void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }
}
