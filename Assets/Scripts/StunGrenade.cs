using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunGrenade: Throwable {

    public float Strength = 10;  //homework line
    


    //void Update() //runs every fraction of sec
    //{
      //  if (Input.GetButtonDown("Fire1") && isActive)
      //  {
      //      Attack();
     //   }
   // }

    void OnCollisionEnter2D(Collision2D coll)
    {
        var player = coll.gameObject.GetComponent<Player>();
        if (isActive && player == null)
        {
            Explode();
        }
    }
    public void Explode()
    {
        // Get reference to all enemies
        var enemies = FindObjectsOfType<Enemy>();

        // Loop through each enemy in list
        foreach (var e in enemies)
        {
            //check if enemy is in bomb radius
            if (Vector3.Distance(this.transform.position, e.transform.position) < Strength) //homework line
            {
                // Set that enemby to Not-Active
                StartCoroutine(Stun(e));

            }
        }
        // Sets not active. Bomb disappears can not be picked up again
        collider2D.enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
    }
    IEnumerator Stun(Enemy e)
    {
        var renderer = e.GetComponent<SpriteRenderer>();

        e.enabled = false;
        renderer.color = new Color(1, 1, 1, 0.4f);
        yield return new WaitForSeconds(5);

        e.enabled = true;
        renderer.color = new Color(1, 1, 1);
    }
}
