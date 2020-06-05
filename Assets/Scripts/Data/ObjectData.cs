using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ObjectData : ScriptableObject
{
    public GameObject[] objects;

    public GameObject GetObject(int id)
    {
        return objects[id];
    }
}
