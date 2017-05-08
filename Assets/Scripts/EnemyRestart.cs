using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRestart : MonoBehaviour
{
    public Player player;

    public GameObject Respawn;
    
    void Start()
    {
     
    }
        void OnCollisionEnter2D(Collision2D coll)
    {
        if (enabled)
        {
           player.transform.position = Respawn.transform.position;
        }
        
    }
}