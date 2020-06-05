using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyData enemyData;

    private void Awake()
    {
        Instantiate(enemyData.GetRandomEnemy(), transform.position, Quaternion.identity, transform.parent);
        Destroy(gameObject);
    }
}
