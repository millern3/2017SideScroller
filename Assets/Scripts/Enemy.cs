﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (!enabled)
        {
            return;
        }
        var player = coll.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.GetOut();
        }
    }
}