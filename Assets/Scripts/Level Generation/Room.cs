using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public Enemy[] enemies;

    PlayerController player;

    bool playerInside = false;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    public void Update()
    {
        if (player == null) return;

        Vector2 dist = new Vector2(transform.position.x - player.transform.position.x, transform.position.y - player.transform.position.y);
        dist.x = Mathf.Abs(dist.x);
        dist.y = Mathf.Abs(dist.y);

        if (!playerInside)
        {
            if (dist.x <= 10 && dist.y <= 5.5f)
            {
                playerInside = true;
                PlayerEntered();
            }
        }
        else
        {
            if (dist.x > 10 && dist.y > 5.5f)
            {
                playerInside = false;
                PlayerExited();
            }
        }
        
    }

    void CheckForEnemies()
    {
        enemies = GetComponentsInChildren<Enemy>();
    }

    public void PlayerEntered()
    {
        CheckForEnemies();

        foreach (Enemy e in enemies)
        {
            e.moving = true;
        }
    }

    public void PlayerExited()
    {
        foreach (Enemy e in enemies)
        {
            e.moving = false;
        }
    }
}
