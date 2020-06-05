using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class EnemyData : ScriptableObject
{
    public GameObject[] enemies;

    public GameObject GetRandomEnemy()
    {
        return enemies[Random.Range(0, enemies.Length)];
    }
}
