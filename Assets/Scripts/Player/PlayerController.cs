using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Experimental.Rendering.Universal;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public string playerName;
    public SpriteRenderer spriteRenderer;
    public Weapon weapon;
    public Light2D light2D;
    public SpriteRenderer hatRenderer;

    public float moveSpeed = 1f;

    Rigidbody2D rb;
    Vector2 move;

    GameGenerator generator;
    GameManager manager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        generator = FindObjectOfType<GameGenerator>();
        manager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        move.x = Input.GetAxis("Horizontal");
        move.y = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);
    }

    public void Generate(Color lightColor)
    {
        WeaponObject chosenWeapon = GameGenerator.instance.weaponData.GetRandomWeapon();
        generator.AddToAlumno(chosenWeapon.alumno);
        BulletObject chosenBullet = GameGenerator.instance.weaponData.GetRandomBullet();
        generator.AddToAlumno(chosenBullet.alumno);

        weapon.Assign(chosenWeapon, chosenBullet);
        light2D.color = lightColor;

        // Hats
        HatObject hat = GameGenerator.instance.characterData.hats[UnityEngine.Random.Range(0, GameGenerator.instance.characterData.hats.Length)];
        GameGenerator.instance.AddToAlumno(hat.alumno);
        hatRenderer.sprite = hat.sprite;

        // Name
        Array values = Enum.GetValues(typeof(Alumno));
        Alumno randomAlumno = (Alumno)values.GetValue(UnityEngine.Random.Range(0, values.Length));

        playerName = randomAlumno.ToString();

        AddScore(0);
    }

    public void AddScore(int amount)
    {
        manager.ChangeScore(amount);
    }

    public void Die()
    {
        manager.Lose();
        Destroy(gameObject);
    }
}
