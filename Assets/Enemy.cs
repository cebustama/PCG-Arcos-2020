using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Experimental.Rendering.Universal;

using TMPro;

public class Enemy : MonoBehaviour
{
    [Header("Settings")]
    public bool moving = false;
    public float size = 1f;
    public Color color;
    public float speed;
    public float damage;
    public float health;

    public Vector2 velocity;
    Rigidbody2D rb;

    [Header("Behaviours")]
    public float random = 0f;
    public float followPlayer = 0f;
    public float line;

    [Header("Modifiers")]
    public EnemyModifier modifiers;

    [Header("References")]
    public Image healthBar;
    public Light2D light2D;
    public SpriteRenderer hatRenderer;
    public TextMeshProUGUI enemyName; 

    float tx, ty;
    Transform player;
    Vector2 step;
    GameGenerator generator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        tx = 0;
        ty = 10000;

        player = FindObjectOfType<PlayerController>().transform;
        //moving = false;

        generator = FindObjectOfType<GameGenerator>();

        Invoke("Generate", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!moving)
        {
            return;
        }

        // F = m * a;
        step = Vector2.zero;

        // Random
        Vector2 randomStep;
        randomStep.x = Mathf.PerlinNoise(tx, ty) * 2 - 1;
        randomStep.y = Mathf.PerlinNoise(ty, tx) * 2 - 1;
        randomStep *= random;
        step += randomStep;

        // Follow
        Vector2 followStep = (player.position - transform.position).normalized;
        followStep *= followPlayer;
        step += followStep;

        // Perlin
        tx += 0.01f;
        ty += 0.01f;
    }

    private void FixedUpdate()
    {
        rb.AddForce(step);
    }

    public void ModifyHealth(float amount)
    {
        health += amount;
    }

    public void Generate()
    {
        light2D.color = generator.gameData.lightColors[Random.Range(0, generator.gameData.lightColors.Length)].color;

        HatObject hat = GameGenerator.instance.characterData.hats[Random.Range(0, GameGenerator.instance.characterData.hats.Length)];
        GameGenerator.instance.AddToAlumno(hat.alumno);
        hatRenderer.sprite = hat.sprite;

        // Modifiers
        enemyName.text = hat.modifier + " Bob";

        speed += hat.speed;
        followPlayer += hat.followAmount;
        random += hat.randomMoveAmount;

        transform.localScale *= hat.sizeFactor;
    }
}
