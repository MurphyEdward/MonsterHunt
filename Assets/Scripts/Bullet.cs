using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    private float _speed = 20f;
    private int _damage = 25;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        _rigidbody.velocity = transform.right * _speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool isMob = collision.TryGetComponent<Health>(out Health health);
        if (isMob) health.TakeDamage(_damage);

        Destroy(gameObject);
    }
}
