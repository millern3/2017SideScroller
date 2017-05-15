using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMove : MonoBehaviour {

    public GameObject ReLocate;
    public Player player;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (enabled)
        {
            player.transform.position = ReLocate.transform.position;
        }

    }

}