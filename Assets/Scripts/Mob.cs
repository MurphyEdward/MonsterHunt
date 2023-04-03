using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    [SerializeField] private static int _damage = 50;
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _target;

    private Rigidbody2D _rigidbody;

    public static int Damage { get { return _damage; } set { _damage = value; } }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        if (transform.position.x > _target.transform.position.x)
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
        Vector2 _distanceToTarget = _target.transform.position - transform.position;
        _rigidbody.velocity = new Vector2(_distanceToTarget.normalized.x * _speed, _rigidbody.velocity.y);
    }
}
