using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public void Set(float length)
    {
        transform.localScale = new Vector3(length, transform.localScale.y, transform.localScale.z);
    }
}
