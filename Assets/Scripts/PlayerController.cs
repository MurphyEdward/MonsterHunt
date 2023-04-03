using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpPower;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;

    private Rigidbody2D _rigidbody;
    private float _horizontalInput;
    private bool _isFacingLeft;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        MoveCharacter();
    }
    private void MoveCharacter()
    {
        _rigidbody.velocity = new Vector2(_horizontalInput * _speed, _rigidbody.velocity.y);
    }

    private void Update()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");

        Jump();
        Flip();
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpPower);
        }

        if (Input.GetButtonUp("Jump") && _rigidbody.velocity.y > 0f)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _rigidbody.velocity.y * 0.5f);
        }
    }

    private void Flip()
    {
        float angle = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        if (!_isFacingLeft && angle < 0 || _isFacingLeft && angle > 0)
        {
            _isFacingLeft = !_isFacingLeft;
            transform.Rotate(0, 180, 0);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, 0.2f, _groundLayer);
    }
}

