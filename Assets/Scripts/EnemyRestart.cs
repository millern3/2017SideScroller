using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRestart : MonoBehaviour
{
    private Vector3 startingPosition;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (!enabled)
        {
            return;
        }
    }
    public void Restart()
    {
        transform.position = startingPosition;
    }
}