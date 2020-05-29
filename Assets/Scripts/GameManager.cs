using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    public GameObject startScreen;
    public GameObject statsPanel;

    public void StartGame()
    {
        startScreen.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            statsPanel.SetActive(!statsPanel.activeSelf);
        }
    }
}
