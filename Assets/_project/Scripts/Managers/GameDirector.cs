using System;
using UnityEngine;

public class GameDirector : MonoBehaviour
{

    
    public LevelManager levelManager;
    public Player player;

    public GamePlayState gamePlayState;

    private void Start()
    {
        RestartLevel();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
    }

    private void RestartLevel()
    {
        levelManager.RestartLevelManager();
        player.RestartPlayer();
    }
}

public enum GamePlayState
{
    AppleNotCollected,
    AppleCollected,
    PlayerEscaped,
}