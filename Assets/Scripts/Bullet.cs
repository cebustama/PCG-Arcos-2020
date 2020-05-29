using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public bool destroyOnCollisionWithWalls = true;
    public float destroyTime = 10f;
    public int damage = 1;

    private void Awake()
    {
        if (destroyTime > 0)
        {
            Destroy(gameObject, destroyTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hitEffect != null)
        {
            GameObject hit = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(hit, 5f);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().ModifyHealth(-damage);
            Destroy(gameObject);
        }

        if (destroyOnCollisionWithWalls && collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
