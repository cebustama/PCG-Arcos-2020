using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public enum RoomDirection { Top, Bottom, Left, Right }
    public RoomDirection roomDirection;

    RoomTemplates templates;
    bool spawned = false;

    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();

        Invoke("SpawnRoom", 0.1f);
    }

    void SpawnRoom()
    {
        if (spawned) return;

        int random;
        switch (roomDirection)
        {
            case RoomDirection.Top:
                random = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[random], transform.position, Quaternion.identity);
                break;
            case RoomDirection.Bottom:
                random = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[random], transform.position, Quaternion.identity);
                break;
            case RoomDirection.Left:
                random = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[random], transform.position, Quaternion.identity);
                break;
            case RoomDirection.Right:
                random = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[random], transform.position, Quaternion.identity);
                break;
        }

        spawned = true;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Spawn Point"))
        {
            if (collider.GetComponent<RoomSpawner>() != null && !collider.GetComponent<RoomSpawner>().spawned && !spawned)
            {
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }

            spawned = true;
        }
    }
}
