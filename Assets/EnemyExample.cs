using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyExample : MonoBehaviour
{
    public float maxSpeed;

    public Vector2 velocity, desiredVelocity;
    Rigidbody2D rb;

    float tx, ty;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        tx = Random.Range(0f, 10000f);
        ty = Random.Range(0f, 10000f);
    }

    private void Update()
    {
        velocity = rb.velocity;
    }

    private void FixedUpdate()
    {
        Walk();

        //rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
    }

    void Walk()
    {
        // RANDOM
        //velocity.x = Random.Range(-1f, 1f);
        //velocity.y = Random.Range(-1f, 1f);

        // PERLIN
        velocity.x = Mathf.PerlinNoise(tx, ty) * 2 - 1;
        velocity.y = Mathf.PerlinNoise(ty, tx) * 2 - 1;
        tx += 0.01f;
        ty += 0.01f;

        velocity *= maxSpeed * Time.fixedDeltaTime;

        rb.velocity = velocity;
    }
}
