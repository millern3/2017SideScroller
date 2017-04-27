using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Weapon {

    public float Strength = 10;  //homework line
    public bool isActive = false;


    void Update() //runs every fraction of sec
    {
        if (Input.GetButtonDown("Fire1") && isActive)
        {
            Attack();
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        var player = coll.gameObject.GetComponent<Player>();
       
        if (isActive && player == null)
        {
            Explode();
        }
    }

    public override void Attack()
    {
        collider2D.enabled = true;
        rigidbody2D.isKinematic = false;
        rigidbody2D.velocity = new Vector2(5,0);
        transform.parent = null;
    }

    public override void GetPickedUp(Player player)
    {
        if (isActive) return;
        isActive = true;
        base.GetPickedUp(player);
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
                e.gameObject.SetActive(false);

            }
        }
        gameObject.SetActive(false);
    }
}
