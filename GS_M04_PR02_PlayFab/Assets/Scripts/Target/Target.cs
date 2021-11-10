using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private float lifeTime = 3.0f;
    private float startTime;
    private float currTime;

    [HideInInspector]
    public TargetSpawner spawner;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        currTime = Time.time - startTime;

        if(currTime > lifeTime)
        {
            if (spawner.numSpawned < spawner.maxNumberSpawned)
                spawner.SpawnNext();
            Destroy(gameObject);
        }
    }
}
