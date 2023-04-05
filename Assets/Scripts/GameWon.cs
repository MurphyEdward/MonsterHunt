using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWon : MonoBehaviour
{
    [SerializeField] private GameObject _youWonUI;
    private void OnEnable()
    {
        MobSpawner.OnAllWavesDestroyed += OnGameIsWon;
    }

    public void OnGameIsWon()
    {
        _youWonUI.SetActive(true);
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        MobSpawner.OnAllWavesDestroyed -= OnGameIsWon;
    }
}
