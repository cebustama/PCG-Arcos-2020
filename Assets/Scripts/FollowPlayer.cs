using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public Vector2 roomSize;

    public Vector2 currentCoords = Vector2.zero;
    float baseZ;

    private void Start()
    {
        currentCoords = GetPlayerCoordinates();
        baseZ = transform.position.z;
    }

    private void Update()
    {
        Vector2 newCoords = GetPlayerCoordinates();
        if (newCoords != currentCoords)
        {
            currentCoords = newCoords;
            MoveToCoords();
        }
    }

    Vector2 GetPlayerCoordinates()
    {
        Vector2 coord;

        coord.x = Mathf.FloorToInt((player.transform.position.x - roomSize.x / 2) / roomSize.x) + 1;
        coord.y = Mathf.FloorToInt((player.transform.position.y - roomSize.y / 2) / roomSize.y) + 1;

        return coord;
    }

    void MoveToCoords()
    {
        transform.position = new Vector3(currentCoords.x * roomSize.x, currentCoords.y * roomSize.y, baseZ);
        ScreenShakeManager.instance.SetNewPosition(transform.position);
    }
}
