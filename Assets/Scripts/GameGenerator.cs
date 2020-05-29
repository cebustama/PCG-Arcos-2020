using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using TMPro;

public class GameGenerator : MonoBehaviour
{
    public static GameGenerator instance;

    [Header("References")]
    public SpriteRenderer floor;
    public TextMeshProUGUI stats;

    [Header("Data")]
    public GameData gameData;
    public AudioData audioData;
    public WeaponData weaponData;
    public CharacterData characterData;

    PlayerController player;

    Dictionary<Alumno, int> alumnoCount; 

    private void Awake()
    {
        instance = this;

        player = FindObjectOfType<PlayerController>();
    }

    private void Start()
    {
        GenerateGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void GenerateGame()
    {
        alumnoCount = new Dictionary<Alumno, int>()
        {
            {Alumno.ALEXANDER, 0},
            {Alumno.BRANCO, 0},
            {Alumno.ENILEV, 0},
            {Alumno.FRANCO, 0},
            {Alumno.JORGE, 0},
            {Alumno.JUAN, 0},
            {Alumno.MAXY, 0},
            {Alumno.PROFE, 0},
            {Alumno.RODRIGO, 0},
            {Alumno.TOMAS, 0}
        };

        GenerateGameData();
        GenerateAudioData();

        GeneratePlayer();

        SendStats();
    }

    void GenerateGameData()
    {
        GameData.ColorOption floorColor = gameData.floorColors[Random.Range(0, gameData.floorColors.Length)];
        Camera.main.backgroundColor = floorColor.color;
        floor.color = floorColor.color;

        // Add count
        AddToAlumno(floorColor.alumno);

        GameData.ColorOption wallColor = gameData.wallColors[Random.Range(0, gameData.wallColors.Length)];
        gameData.tileMaterial.color = wallColor.color;

        // Add count
        AddToAlumno(wallColor.alumno);
    }

    void GenerateAudioData()
    {
        AudioData.AudioOption song = audioData.songs[Random.Range(0, audioData.songs.Length)];
        AudioManager.instance.PlayMusic(song.clip);

        AddToAlumno(song.alumno);
    }

    void GeneratePlayer()
    {
        GameData.ColorOption lightColor = gameData.lightColors[Random.Range(0, gameData.lightColors.Length)];
        player.Generate(lightColor.color);
        AddToAlumno(lightColor.alumno);
    }

    public void AddToAlumno(Alumno alumno)
    {
        alumnoCount[alumno]++;
    }

    public void SendStats()
    {
        stats.text = "";

        int total = 0;
        foreach (Alumno a in alumnoCount.Keys)
        {
            total += alumnoCount[a];
        }

        foreach (Alumno a in alumnoCount.Keys)
        {
            stats.text += a.ToString() + " " + (((float)alumnoCount[a] / (float)total) * 100f) + "%\n";
        }
    }
}
