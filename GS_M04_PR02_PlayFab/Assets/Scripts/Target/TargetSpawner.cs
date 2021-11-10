using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public int maxNumberSpawned = 11;
    public int numSpawned = 0;
    public GameObject target;

    public void SpawnNext()
    {
        numSpawned++;
        if (numSpawned < maxNumberSpawned)
        {   
            Vector3 newDir = new Vector3(Random.Range(-7.5f, 7.5f), Random.Range(-3.5f, 3.5f), 0f);
            GameObject obj = GameObject.Instantiate(target, newDir, Quaternion.identity);
            obj.GetComponent<Target>().spawner = this;
        }
    }
}
