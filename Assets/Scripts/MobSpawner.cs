using System.Collections;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _mobPrefab;
    [SerializeField] private float _startSpawnDelay = 30;

    private void Start()
    {
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        for (int iterationCount = 0; true; iterationCount++)
        {                     
            Instantiate(_mobPrefab, transform);
            yield return new WaitForSeconds(_startSpawnDelay - iterationCount);
        }
    }
}
