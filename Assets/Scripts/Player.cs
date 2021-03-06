﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int health = 100;
    public float speed = 5;
    public float jumpSpeed = 5;
    public float deadZone = -3;
    public bool air;
    public bool canFly = false;

    //Weapon in class
    public Weapon currentWeapon;
    private List<Weapon> weapons = new List<Weapon>();
    //WeaponShootEgg
    public Transform firePoint;
    public GameObject Bullet;

    private SpriteRenderer sr;
    private Vector3 startingPosition;
    private Animator anim;
    private bool grounded;

    new Rigidbody2D rigidbody;
    GM _GM;

  //for initialization
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

            if (Input.GetButtonDown("Jump") && (v.y == 0 || canFly))
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
        //Change weapon
        if (Input.GetButtonDown("Fire2") && currentWeapon != null)
        {
            int i = (weapons.IndexOf(currentWeapon) + 1) % weapons.Count; // % is remainder of number (modulo)
            SetCurrentWeapon(weapons[i]);
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
   
    //Funciton to add new weapon and set current weapon
    public void AddWeapon(Weapon w)
    {
        weapons.Add(w);
        SetCurrentWeapon(w);
    }
    public void SetCurrentWeapon (Weapon w)
    {
        if(currentWeapon != null)
        {
            currentWeapon.gameObject.SetActive(false);
        }

        currentWeapon = w;

        if (currentWeapon != null)
        {
            currentWeapon.gameObject.SetActive(true);
        }

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        air = false;
        var weapon = coll.gameObject.GetComponent<Weapon>();
        if (weapon != null)
        {
            weapon.GetPickedUp(this);
          
        }
        int move = 0;
        //MoveablePlatform 
        if (move != 0 && transform.parent != null) 
        {
            GetComponent<Rigidbody2D>().isKinematic = false;
            transform.parent = null;
        }
        if ((grounded) && Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().isKinematic = false;
            transform.parent = null;
        }
        if (coll.transform.tag == "MoveablePlatform")
        {
            transform.parent = coll.transform;
        }
    }
    void OnCollisionExit2D(Collision2D coll)
    {
        air = true;
        if (coll.transform.tag == "MoveablePlatform")
        {
            transform.parent = null;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Instantiate(Bullet, firePoint.position, firePoint.rotation);
        }
    }
    //Respawn player
    public void RespawnPlayer()
    {
        Debug.Log("PlayerRespawn");
    }
}

