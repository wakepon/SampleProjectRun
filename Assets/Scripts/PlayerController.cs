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
    private Vector3 _startPosition;

    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _startPosition = transform.position;
    }

    public void ReadyToStart()
    {
        transform.position = _startPosition;
        _rigidbody2D.simulated = true;
    }

    public void Stop()
    {
        _rigidbody2D.simulated = false;
    }

    void Update()
    {
        Run();
        JumpOperation();
    }

    void Run()
    {
        if (groundChecker.IsGround)
        {
            _rigidbody2D.velocity = new Vector2(runSpeed, _rigidbody2D.velocity.y);
        }
    }

    void JumpOperation()
    {
        //The longer the player hold the button down, the higher he jump.
        if (Input.GetMouseButton(0))
        {
            //If the character grounded, jump.
            if (groundChecker.IsGround && !_isJumping)
            {
                _jumpStartHeight = _rigidbody2D.position.y;
                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpSpeed);
                _isPassedJumpingTop = false;
            }

            _isJumping = true;
        }
        else // release the button, then stop jumping
        {
            _isJumping = false;
            _isPassedJumpingTop = true;
        }

        // when the player is jumping, and has not passed the top of the jump yet
        if (_isJumping && !_isPassedJumpingTop)
        {
            if ((_jumpStartHeight + jumpHeight) > _rigidbody2D.position.y) // when the player has not passed the top of the jump yet
            {
                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpSpeed);
            }
            else // the player has passed the top of the jump
            {
                _isPassedJumpingTop = true;
            }
        }
    }
}