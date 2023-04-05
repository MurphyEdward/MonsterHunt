using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverUI;

    private void OnEnable()
    {
        Health.OnPlayerKilled += OnGameOver; 
    }

    public void OnGameOver()
    {
        _gameOverUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    private void OnDisable()
    {
        Health.OnPlayerKilled -= OnGameOver;
    }
}
