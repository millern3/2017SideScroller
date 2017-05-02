using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Throwable {

    public float Strength = 10;  //homework line
   

    void OnCollisionEnter2D(Collision2D coll)
    {
        var player = coll.gameObject.GetComponent<Player>();
       
        if (isActive && player == null)
        {
            Explode();
        }
    }

    public void Explode()
    { // Get reference to all enemies
        var enemies = FindObjectsOfType<Enemy>();

        // Loop through each enemy in list
        foreach (var e in enemies)
        {
            //check if enemy is in bomb radius
            if (Vector3.Distance(this.transform.position, e.transform.position) < Strength) //homework line
            {
                e.gameObject.SetActive(false);

            }
        }
        gameObject.SetActive(false);
    }
}
