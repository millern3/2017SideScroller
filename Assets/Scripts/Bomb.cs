using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    public float Strength = 10;  //homework line
    public bool isActive = false;

    private new Rigidbody2D rigidbody2D;
    private new Collider2D collider2D;

    void Start() //Private
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<Collider2D>();
    }

    void Update() //runs every fraction of sec
    {
        if (Input.GetButtonDown("Fire1") && isActive)
        {
            Throw();
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        var player = coll.gameObject.GetComponent<Player>();
        if (player != null && !isActive)
        {
            GetPickedUp(player);
        }
        if (isActive && player == null)
        {
            Explode();
        }
    }

    public void Throw()
    {
        collider2D.enabled = true;
        rigidbody2D.isKinematic = false;
        rigidbody2D.velocity = new Vector2(5,0);
        transform.parent = null;
    }

    public void GetPickedUp(Player player)
    {
        isActive = true;
        collider2D.enabled = false;
        rigidbody2D.isKinematic = true;
        rigidbody2D.velocity = new Vector2();
        transform.parent = player.transform;
        transform.localScale = new Vector3(.5f, .5f);
        transform.localPosition = new Vector3(.4f, .4f);
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
