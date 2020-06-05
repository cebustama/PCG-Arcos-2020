using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using TMPro;
using System;

public class GameGenerator : MonoBehaviour
{
    public static GameGenerator instance;

    [Header("UI")]
    public TextMeshProUGUI gameTitle;
    public TextMeshProUGUI gameStory;
    public TextMeshProUGUI gameWinText;
    public TextMeshProUGUI gameLoseText;

    [Header("References")]
    public SpriteRenderer floor;
    public TextMeshProUGUI stats;

    [Header("Data")]
    public GameData gameData;
    public AudioData audioData;
    public WeaponData weaponData;
    public CharacterData characterData;
    public ObjectData objectData;

    PlayerController player;

    Dictionary<Alumno, int> alumnoCount;
    Alumno villano;
    string chosenReason;

    [HideInInspector]
    public int objectId;

    [HideInInspector]
    public int numberOfObjects;

    public List<string> reasons = new List<string>
    {
        "mató a mis padres.",
        "No me deja jugar en mi xbox.",
        "Se acabó el agua.",
        "No hay pan.",
        "está modo owo",
        "Tomó mi chocman.",
        "Dijo soluciones al revés.",
        "necesitamos una razón para derrotar al enemigo.",
        "YOLO.",
        "se robó mi cuchara.",
        "se comió mi manjarate",
        "La profecía lo dice.",
        "Quería ser un héroe.",
        "quiero la dominación mundial.",
        "Me despertó mientras dormía.",
        "No compró el té.",
        "Es team Jacob (referencia twilight)(que asco, qué mal sasón OwO)",
        "Se tomó mi chocomilk.",
        "La historia tiene que continuar.",
        "Se llevó a mi gato.",
        "Me debía plata.",
        "me puso mala nota"
    };

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

        GenerateGameMenu();

        SendStats();
    }

    void GenerateGameMenu()
    {
        gameTitle.text = GenerateGameTitle();

        gameStory.text = GenerateGameStory();

        gameWinText.text = player.playerName + " ha derrotado a " + villano.ToString() + " gracias al poder de los " + objectData.GetObject(objectId).name;
        gameLoseText.text = player.playerName + " ha sido derrotado por " + villano.ToString() + " quien nunca se arrepintió porque " + chosenReason;
    }

    string GenerateGameTitle()
    {
        string objectName = objectData.GetObject(objectId).name;
        return player.playerName + " y los " + numberOfObjects + " " + objectName;
    }

    string GenerateGameStory()
    {
        Array values = Enum.GetValues(typeof(Alumno));
        villano = (Alumno)values.GetValue(UnityEngine.Random.Range(0, values.Length));
        chosenReason = reasons[UnityEngine.Random.Range(0, reasons.Count)];
        return player.playerName + " debe derrotar al malvado " + villano.ToString() +  " porque " + chosenReason;
    }

    void GenerateGameData()
    {
        GameData.ColorOption floorColor = gameData.floorColors[UnityEngine.Random.Range(0, gameData.floorColors.Length)];
        Camera.main.backgroundColor = floorColor.color;
        floor.color = floorColor.color;

        // Add count
        AddToAlumno(floorColor.alumno);

        GameData.ColorOption wallColor = gameData.wallColors[UnityEngine.Random.Range(0, gameData.wallColors.Length)];
        gameData.tileMaterial.color = wallColor.color;

        // Add count
        AddToAlumno(wallColor.alumno);

        objectId = UnityEngine.Random.Range(0, objectData.objects.Length);
        numberOfObjects = UnityEngine.Random.Range(6, 13);
    }

    void GenerateAudioData()
    {
        AudioData.AudioOption song = audioData.songs[UnityEngine.Random.Range(0, audioData.songs.Length)];
        AudioManager.instance.PlayMusic(song.clip);

        AddToAlumno(song.alumno);
    }

    void GeneratePlayer()
    {
        GameData.ColorOption lightColor = gameData.lightColors[UnityEngine.Random.Range(0, gameData.lightColors.Length)];
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
