using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int health = 100;
    public float speed = 5;
    public float jumpSpeed = 5;
    public float deadZone = -3;
    public bool air;
    public bool canFly = false;
    public Weapon currentWeapon;

    private SpriteRenderer sr;
    private Vector3 startingPosition;
    private Animator anim;

    new Rigidbody2D rigidbody;
    GM _GM;


    // Use this for initialization
    void Start () {
        startingPosition = transform.position;
        rigidbody = GetComponent<Rigidbody2D>();
        _GM = FindObjectOfType<GM>();

        anim = GetComponent<Animator> ();
        air = true;
        sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //Apply Movement
        float x = Input.GetAxisRaw("Horizontal");
        Vector2 v = rigidbody.velocity;
        v.x = x * speed;

        if (v.x != 0)
        {
            anim.SetBool("Running", true);
        }
        else
        {
            anim.SetBool("Running", false);
        }

        if (v.x > 0)
        {
            sr.flipX = false;
        }
        else if (v.x < 0)
        {
            sr.flipX = true;
        }

        if (Input.GetButtonDown("Jump") && (v.y == 0 || canFly) )
        { 
            v.y = jumpSpeed;
        }
        if (v.y != 0)
        {
            anim.SetBool("Air", true);
        }
        else
        {
            anim.SetBool("Air", false);
        }

        rigidbody.velocity = v;

        //Attack with a weapon if you have one
        if (Input.GetButtonDown("Fire1") && currentWeapon !=null)
        {
           currentWeapon.Attack();
        }
        //Check for out
        if (transform.position.y < deadZone)
        {
            GetOut();
        }

        //rigidbody.velocity = new Vector2(x * speed, rigidbody.velocity.y);
        // rigidbody.AddForce(new Vector2(x * speed, 0));
    }
    public void GetOut()
    {
        _GM.SetLives(_GM.GetLives() - 1);
        transform.position = startingPosition;
        Debug.Log("You're Out");
    }
   
    public void PowerUp(){
        anim.SetTrigger("Powered");
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        air = false;
        var weapon = coll.gameObject.GetComponent<Weapon>();
        if (weapon != null)
        {
            weapon.GetPickedUp(this);
            currentWeapon = weapon;
        }
    }
    void OnCollisionExit2D(Collision2D coll)
    {
        air = true;
    }

    //Moveable Platform
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag == "MovingPlatform")
        {
            transform.parent = collision.transform;
        }
    }
    void OnCollisionLeave2D(Collision2D collision)
    {
        if (collision.transform.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }
}

