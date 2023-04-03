using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    

    [SerializeField]private PlayerController _target;
    private int _attackDelay = 2;

    [SerializeField] private Transform _shootPoint;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _rotatePoint; 

     
    void Start()
    {
        _target = FindObjectOfType<PlayerController>();
        StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        while (true) {
            Shoot();
            
            yield return new WaitForSeconds(_attackDelay);
        }
    }


    private void Shoot()
    {

        Vector3 direction = _target.transform.position - _shootPoint.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _rotatePoint.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));


        Instantiate(_bulletPrefab, _shootPoint.position, _shootPoint.rotation);

        
    }
}
