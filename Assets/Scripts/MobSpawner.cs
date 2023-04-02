using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{

    [SerializeField]private GameObject _mobPref;


    private void Start()
    {
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {

        for (int iterationCount = 0; true; iterationCount++)
        {                     
            Instantiate(_mobPref, transform);
            yield return new WaitForSeconds(30 - iterationCount);
        }
    }
}
