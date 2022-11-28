using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private Menu menu;
    public GameState gameState;
    public static GameManager Instance;
    private int score;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        gameState = GameState.Begin;
        menu.ShowStartText();
    }

    public void Lose()
    {
        gameState = GameState.End;
        menu.ShowRestartText();
    }
    private void GameStart()
    {
        player.Initialize();
        gameState = GameState.Start;
        menu.HideAll();
    }
    private void Update()
    {
        if (gameState == GameState.Begin && Input.GetKeyDown(KeyCode.Space))
        {
            GameStart();
        }
        if(gameState == GameState.End && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    public enum GameState
    {
        Begin,
        Start,
        End,
    }

    public void IncreaseScore()
    {
        score++;
        menu.UpdateScore(score);
    }
}
