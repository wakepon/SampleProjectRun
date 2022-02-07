using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform followObj;
    [SerializeField] private float xOffset;

    void Update()
    {
        transform.position = new Vector3(
            followObj.transform.position.x + xOffset
            , transform.position.y
            , transform.position.z
            );
    }
}
