using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    public GameObject startScreen;
    public GameObject winScreen;
    public GameObject loseScreen;
    public GameObject statsPanel;
    public TextMeshProUGUI score;

    public bool gameStarted = false;

    public int numObjects = 0;
    int objectsObjective;

    public void StartGame()
    {
        startScreen.SetActive(false);
        gameStarted = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            statsPanel.SetActive(!statsPanel.activeSelf);
        }
    }

    public void ChangeScore(int amount)
    {
        numObjects += amount;
        string objectName = GameGenerator.instance.objectData.objects[GameGenerator.instance.objectId].name;
        score.text = objectName + ": " + numObjects + "/" + GameGenerator.instance.numberOfObjects;

        // END GAME
        if (numObjects >= GameGenerator.instance.numberOfObjects)
        {
            Time.timeScale = 0;
            winScreen.SetActive(true);
            score.gameObject.SetActive(false);
        }
    }

    public void Lose()
    {
        Time.timeScale = 0;
        loseScreen.SetActive(true);
        score.gameObject.SetActive(false);
    }
}
