using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class MobSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _mobPrefab;
    [SerializeField] private float _startSpawnDelay = 5f;

    public static Action OnAllWavesDestroyed;
    public static Action<int> OnNewWaveStarts;

    private void Start()
    {
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        for (int iterationCount = 0; iterationCount < _startSpawnDelay; iterationCount++)
        {
            OnNewWaveStarts?.Invoke(iterationCount+1);
            Instantiate(_mobPrefab, transform);
            yield return new WaitForSeconds(_startSpawnDelay - iterationCount);
        }

        OnAllWavesDestroyed?.Invoke();
    }

    
        
            
}
