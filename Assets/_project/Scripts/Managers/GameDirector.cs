using System;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public static GameDirector instance;

    public LevelManager levelManager;
    public Player player;

    public GamePlayState gamePlayState;

    private void Awake()
    {
        instance = this;
    }

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
        gamePlayState = GamePlayState.AppleNotCollected;
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