using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GroundCreator : MonoBehaviour
{
    [SerializeField] private Ground groundPrefab;
    [SerializeField] private float birthTiming = 15;
    [SerializeField] private float minY = -9;
    [SerializeField] private float maxY = 3;
    [SerializeField] private float minLength = 6;
    [SerializeField] private float maxLength = 10;
    [SerializeField] private float maxYDifferece = 5;
    [SerializeField] private Vector3 firstGroundPos;
    [SerializeField] private float groundInterval = 2;
    private List<Ground> _grounds = new List<Ground>();
    private float latestEdge = 0.0f;

    public void ResetGrounds()
    {
        foreach (var ground in _grounds)
        {
            Destroy(ground.gameObject);
        }
        _grounds.Clear();

        latestEdge = 0.0f;
    }


    void Update()
    {
        while ((latestEdge - Camera.main.transform.position.x) < birthTiming)
        {
            BirthLatestGround();
        }
    }

    void BirthLatestGround()
    {
        var latestGround = _grounds.LastOrDefault();

        var ground = Birth();

        float groundLength = Random.Range(minLength, maxLength);
        if (latestGround == null) //set first ground
        {
            groundLength = maxLength;//use maxLength on first ground
            ground.transform.position = firstGroundPos;
        }
        else
        {
            ground.transform.position = GetNextGroundPos(latestGround.transform, groundLength);
        }
        ground.Set(groundLength);

        latestEdge = ground.transform.position.x + groundLength / 2.0f;
    }

    Ground Birth()
    {
        var ground = Instantiate(groundPrefab);
        _grounds.Add(ground);
        return ground;
    }

    Vector3 GetNextGroundPos(Transform latestGround, float length)
    {
        Vector3 pos = new Vector3();
        pos.x = latestEdge + groundInterval + length / 2.0f;
        float minY = Mathf.Max(latestGround.position.y - maxYDifferece, this.minY);
        float maxY = Mathf.Min(latestGround.position.y + maxYDifferece, this.maxY);
        pos.y = Random.Range(minY, maxY);
        pos.z = 0.0f;

        return pos;
    }
}