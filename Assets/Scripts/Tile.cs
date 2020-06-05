using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [System.Serializable]
    public struct SpawnableObject
    {
        public GameObject prefab;
        public float weight;
    }

    public SpawnableObject[] spawnableObjects;

    private void Start()
    {
        float totalWeights = 0;
        
        foreach (SpawnableObject o in spawnableObjects)
        {
            totalWeights += o.weight;
        }

        float random = Random.Range(0f, totalWeights);

        SpawnableObject s = new SpawnableObject();
        float weight = 0;
        foreach (SpawnableObject o in spawnableObjects)
        {
            if (random > weight && random < weight + o.weight)
            {
                s = o;
            }
        }

        if (s.prefab == null) return;

        Instantiate(s.prefab, transform.position, Quaternion.identity, transform.parent);

        Destroy(gameObject);
    }
}
