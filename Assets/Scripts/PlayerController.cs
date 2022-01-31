using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GroundChecker groundChecker;
    [SerializeField] private float runSpeed = 3.0f;
    [SerializeField] private float jumpSpeed = 5.0f;
    [SerializeField] private float jumpHeight = 3.0f;

    private Rigidbody2D _rigidbody2D;
    private bool _isJumping = false;
    private bool _isPassedJumpingTop = false;
    private float _jumpStartHeight = 0.0f;
    private Vector3 startPosition;

    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    public void ReadyToStart()
    {
        transform.position = startPosition;
        _rigidbody2D.simulated = true;
    }

    public void Stop()
    {
        _rigidbody2D.simulated = false;
    }

    void Update()
    {
        _rigidbody2D.velocity = new Vector2(runSpeed, _rigidbody2D.velocity.y);
        JumpOperation();
    }

    void JumpOperation()
    {
        if (Input.GetMouseButton(0))
        {
            if (groundChecker.IsGround && !_isJumping)
            {
                _jumpStartHeight = _rigidbody2D.position.y;
                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpSpeed);
                _isPassedJumpingTop = false;
            }

            _isJumping = true;
        }
        else
        {
            _isJumping = false;
            _isPassedJumpingTop = true;
        }

        if (_isJumping && !_isPassedJumpingTop)
        {
            if ((_jumpStartHeight + jumpHeight) > _rigidbody2D.position.y)
            {
                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpSpeed);
            }
            else
            {
                _isPassedJumpingTop = true;
            }
        }
    }
}