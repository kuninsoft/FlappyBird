using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event EventHandler<EventArgs> GameOver;
    public static bool IsGameRunning = true;
    public static GameManager Instance { get; set; }

    private void Awake()
    {
        HandleSingleton();

        PlayerLifetime.Died += OnGameOver;
    }

    private void HandleSingleton()
    {
        if (Instance is not null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void OnGameOver(object sender, EventArgs args)
    {
        GameOver?.Invoke(this, EventArgs.Empty);

        Debug.Log("Game over!");
        IsGameRunning = false;
    }
}
