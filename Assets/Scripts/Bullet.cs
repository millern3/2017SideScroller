using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public Rigidbody2D rb;
    public Vector2 velocity;

	// Use this for initialization
	void Start ()
    {
        Destroy(this.gameObject, 10);
        rb = GetComponent< Rigidbody2D > ();
        velocity = rb.velocity;
    
	}
	
	// Update is called once per frame
	void Update ()
    {
	if (rb.velocity.y < velocity.y)
        {
            rb.velocity = velocity;
        }	
	}
    void OnCollisionEnter2D(Collision2D collision)
    {
        rb.velocity = new Vector2(velocity.x, -velocity.y);

        
        if (collision.collider.tag == "Deadly")
        {
            Destroy(collision.gameObject);
            Explode ();
        }
        if (collision.contacts[0].normal.x != 0)
        {
            Explode();
        }
    }
    void Explode()
    {
        Destroy(this.gameObject);
    }

}
