using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") || collider.CompareTag("Bullet") || collider.CompareTag("Enemy")) return;

        Destroy(collider.gameObject);
    }
}
