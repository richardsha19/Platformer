using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Vector2 startingPosition;

    private void Start()
    {
        startingPosition = transform.position;
    }

    private Vector2 randomPos()
    {
        return new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
        //random on x, random on y;
    }

    private Vector2 GetRoamingPosition()
    {
        return startingPosition + randomPos() * Random.Range(10f, 70f);
    }
}
