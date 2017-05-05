using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterWeapon : MonoBehaviour {

    public float speed;
    public Player player;
    public Rigidbody projectile;
	
    // Use this for initialization
	void Start () {
        player = FindObjectOfType<Player>();

        if (player.transform.localScale.x < 0)
            speed = -speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
           Rigidbody instantiateProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
           new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);

        }
    }
        void OnTriggerEnter2D(Collider2D other)
        {

        if (other.tag == "Enemy")
          {
             Destroy(other.gameObject);
          }
        Destroy(gameObject);
    }
}
