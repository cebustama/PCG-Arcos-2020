using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImportantObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            player.AddScore(1);
            Destroy(gameObject);
        }
    }
}
