using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private CharacterController character;
    [SerializeField] private GameObject InGamePanel;
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private Text scoreInGame;
    [SerializeField] private Text scoreEndGame;


    private void Awake()
    {
        character = FindObjectOfType<CharacterController>();
    }

    private void Start()
    {
        GameOverPanel.SetActive(false);
        InGamePanel.SetActive(true);
    }

    private void Update()
    {
        if(character.IsDead == true)
        {
            GameOverPanel.SetActive(true);
            InGamePanel.SetActive(false);
            ScoreEndGameRefresh();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ScoreInGameRefresh()
    {
        scoreInGame.text = "Score: " + character.Score.ToString();
    }

    public void ScoreEndGameRefresh()
    {
        scoreEndGame.text = "Score:" + character.Score.ToString();
    }

    public void MainMenuLoad()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
