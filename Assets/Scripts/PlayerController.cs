using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpPower;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D _rigidbody;
    private float _horizontalInput;
    private bool _isFacingLeft;

    private bool _isGrounded = true;

    private Vector2 _movement;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");

        Jump();
        Flip();
    }

    private void MoveCharacter()
    {
        _rigidbody.velocity = new Vector2(_horizontalInput * _speed, _rigidbody.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
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

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    private void Flip()
    {
        if (!_isFacingLeft && _horizontalInput < 0f || _isFacingLeft && _horizontalInput > 0f)
        {
            _isFacingLeft = !_isFacingLeft;
            transform.Rotate(0, 180, 0);
        }
    }

}

