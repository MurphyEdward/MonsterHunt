using UnityEngine;
using TMPro;

public class GameScore : MonoBehaviour
{
    private int _score;
    public int Score 
    { 
        get { return _score; }
    }

    [SerializeField] private TextMeshProUGUI _scoreText;

    private void OnEnable()
    {
        Health.OnMobKilled += IncreaseScore;
        Health.OnMobKilled += UpdateScore;
    }

    private void OnDisable()
    {
        Health.OnMobKilled -= IncreaseScore;
        Health.OnMobKilled -= UpdateScore; 
    }

    private void UpdateScore()
    {
        _scoreText.SetText("Score: " + _score);
    }

    private void IncreaseScore() => _score++;
}
