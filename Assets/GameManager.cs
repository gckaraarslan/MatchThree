using System.Collections;
using System.Collections.Generic;
using Components.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Button exitGameButton;
    [SerializeField] private Button startButton;
    [SerializeField] private Button continouButton;
    [SerializeField] private Button nextLevelButton;
   //  private int timer;
    
    
    private int score;

     public PlayerScoreTMP _playerScoreTMP;
   
   
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject gameOverTextImage;
    [SerializeField] private GameObject congratulationsTextImage;
    

    
    private bool isPaused;
    void Start()
    {
        //timer = 0;
        score = _playerScoreTMP._playerScore;
        
        
        isPaused = false;
       
        exitGameButton.gameObject.SetActive(false);
        continouButton.gameObject.SetActive(false);
        nextLevelButton.gameObject.SetActive(false);
        gameOverTextImage.gameObject.SetActive(false);
        congratulationsTextImage.gameObject.SetActive(false);
    }

   
    void Update()
    {
     
        //timer++;
        if (isPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }

        score = _playerScoreTMP._playerScore;
        GameStatu();
    }

    public void StartButtonClicked()
    {
        gameOverPanel.SetActive(false);
        exitGameButton.gameObject.SetActive(true);
    }

    public void ExitButtonClicked()
    {
        isPaused = true;
        gameOverPanel.SetActive(true);
        startButton.gameObject.SetActive(false);
        continouButton.gameObject.SetActive(true);
        nextLevelButton.gameObject.SetActive(false);
        
    }

    public void ContinouButtonClicked()
    {
        isPaused = false;
        gameOverPanel.gameObject.SetActive(false);
    }

    public void GameStatu()
    {
        if (score > 500 )
        {
            _playerScoreTMP._playerScore = 0;
            isPaused = true;
            gameOverPanel.SetActive(true);
            congratulationsTextImage.gameObject.SetActive(true);
            nextLevelButton.gameObject.SetActive(true);
            startButton.gameObject.SetActive(false);
            continouButton.gameObject.SetActive(false);
            
        }

        // if (Time.time=20f && score < 500)
        // {
        //     isPaused = true;
        //     gameOverPanel.SetActive(true);
        //     gameOverTextImage.gameObject.SetActive(true);
        //     nextLevelButton.gameObject.SetActive(false);
        //     startButton.gameObject.SetActive(true);
        //     continouButton.gameObject.SetActive(false);
        // }

      
        
    }

    public void NextLevelButtonClicked()
    {
        isPaused = false;
        
        _playerScoreTMP._playerScore = 0;
        gameOverPanel.SetActive(false);
        exitGameButton.gameObject.SetActive(true);
       
    }
    
} 
