using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _player;

    private bool _isFacingLeft;
    private Rigidbody2D _rigidbody;

    private int _HP = 100;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        if((transform.position.x < _player.position.x && _isFacingLeft) || (transform.position.x > _player.position.x && !_isFacingLeft))
        {
            Flip();
        }


    }
    private void FixedUpdate()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        
        _rigidbody.velocity = new Vector2(_speed, _rigidbody.velocity.y);
    }

    private void Flip()
    {
            _speed *= -1;
            _isFacingLeft = !_isFacingLeft;
            transform.Rotate(0, 180, 0);
    }

    public void takeDamage(int damage)
    {
        if (damage >= _HP) Destroy(gameObject);
        _HP -= damage;
    }
}
