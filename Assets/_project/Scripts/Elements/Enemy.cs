using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameDirector _gameDirector;

    public void StartEnemy(GameDirector gameDirector)
    {
        _gameDirector = gameDirector;
    }

    private void Update()
    {
        if (_gameDirector.gamePlayState == GamePlayState.AppleCollected)
        {
            FollowPlayer();
        }
    }

    private void FollowPlayer()
    {
        print("In Player Follow");
    }
}
