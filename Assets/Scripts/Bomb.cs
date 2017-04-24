using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    public int Strength = 10;  //homework line

    void OnCollisionEnter2D(Collision2D coll)
    {
        var player = coll.gameObject.GetComponent<Player>();
        if (player != null)
        {
            var enemies = FindObjectsOfType<Enemy>();
            foreach(var e in enemies)
            {
                if (Vector3.Distance(this.transform.position, e.transform.position) < Strength) //homework line
                {
                    e.gameObject.SetActive(false);
                }
            } 
        }
    }
}
