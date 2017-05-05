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
                // Set that enemy to Not-Active
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
        var animator = e.GetComponent<Animator>();

        e.enabled = false;
        if(animator != null)
        {
            animator.enabled = false;
        }
        //starting with new variable i in for loop
        for (int i = 0; i < 8; i++) //i++ is same as i = i + 1
        {
            renderer.color = new Color(1, 1, 1, 1 - (i * .1f));
            yield return new WaitForSeconds(.3f);
        }
        
        yield return new WaitForSeconds(5);

    
        for (int i = 0; i < 11; i++) //i++ is same as i = i + 1
        {
            renderer.color = new Color(1, 1, 1, i * .1f);
            yield return new WaitForSeconds(.3f);
        }
        if (animator != null)
        {
            animator.enabled = true;
        }
        e.enabled = true;
    }
}
