using UnityEngine;

using TMPro;

public class WaveNumber : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _waveNumberText;

    private void OnEnable()
    {
        MobSpawner.OnNewWaveStarts += WaveTextShow;
    }

    private void WaveTextShow(int waveNumber)
    {
        _waveNumberText.gameObject.SetActive(true);
        Invoke("WaveTextDisable", 2f);
        _waveNumberText.SetText("Wave " + waveNumber);
    }

    private void WaveTextDisable()
    {
        _waveNumberText.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        MobSpawner.OnNewWaveStarts -= WaveTextShow;
    }
}
