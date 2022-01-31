using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private static readonly string GroundTag = "Ground";

    private bool _isGroundEnter = false;
    private bool _isGroundExit = false;
    private int _groundCounter = 0;

    public bool IsGround => _groundCounter > 0;
    public bool IsGroundEnter => _isGroundEnter;
    public bool IsGroundExit => _isGroundExit;

    void LateUpdate()
    {
        _isGroundEnter = false;
        _isGroundExit = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(GroundTag))
        {
            _groundCounter++;
            _isGroundEnter = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(GroundTag))
        {
            _groundCounter--;
            _isGroundExit = true;
        }
    }
}
