using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class HatObject : ScriptableObject
{
    public Sprite sprite;
    public string modifier;

    public Alumno alumno;

    // Modificadores de enemigos
    public float speed = 0f;
    public float followAmount = 0f;
    public float randomMoveAmount = 0f;
    public float sizeFactor = 1f;
    public float hpBonus = 0f;
}
