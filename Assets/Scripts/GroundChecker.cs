using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private const string GroundTag = "Ground";

    private int _groundCounter = 0;

    public bool IsGround => _groundCounter > 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(GroundTag))
        {
            _groundCounter++;
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(GroundTag))
        {
            _groundCounter--;
        }
    }
}
