using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SWS;

public class Manager : MonoBehaviour
{
    public delegate void Action();
    public static event Action TapToStart;
    public static event Action OnEnd;

    [SerializeField] private splineMove myPlayer;
    //[SerializeField] private GameState _GameState;
    [SerializeField] private GameObject tapPanel, endPanel;
    [SerializeField] private Button restartButton;
    private void OnEnable()
    {
        //TapToStart += StartGame;
        //OnEnd += EndGame;
        restartButton.onClick.AddListener(RestartGame);
    }

    private void OnDisable()
    {
        //TapToStart -= StartGame;
        //OnEnd -= EndGame;
        restartButton.onClick.RemoveListener(RestartGame);

    }

    /*public void ChangeGameState(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.Start:
                TapToStart?.Invoke();
                break;
            case GameState.End:
                OnEnd?.Invoke();
                break;
        }
    }*/

    public void StartGame()
    {
        myPlayer.StartMove();
        tapPanel.SetActive(false);
    }

    public void EndGame()
    {
        endPanel.SetActive(true);
    }

    void RestartGame()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
}
