using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _crystal;

    private Rigidbody2D _rigidbody;
    private float _target;

    private void Start()
    {
        
        _crystal = GameObject.Find("Crystal");
        _rigidbody = GetComponent<Rigidbody2D>();
        _target = (_crystal.transform.position.x - transform.position.x);
        if (transform.position.x > _crystal.transform.position.x)
        {
            transform.Rotate(0, 180, 0);
        }

    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        bool b1 = transform.position.x + 1 < _crystal.transform.position.x &&
            transform.position.x - 1 > _crystal.transform.position.x;
        Debug.Log(transform.position.x + 1 < _crystal.transform.position.x);
        
        if (transform.position.x + 1 > _crystal.transform.position.x &&
            transform.position.x - 1 < _crystal.transform.position.x)
        {
            _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
            return;
        }
        _rigidbody.velocity = new Vector2(_target * _speed / 100, _rigidbody.velocity.y);
    }
}
