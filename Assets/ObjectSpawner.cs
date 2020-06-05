using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public ObjectData objectData;

    private void Awake()
    {
        Instantiate(objectData.GetObject(GameGenerator.instance.objectId), transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
