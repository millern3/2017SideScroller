using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterWeapon : MonoBehaviour {

    public Vector2 velocity;
    public Player player;
    public GameObject projectile;
    bool canShoot = true;
    public Vector2 offset = new Vector2(0.4f, 0.1f);
    public float wait = 1f;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && canShoot)
        {
            GameObject gameObject = (GameObject)Instantiate(projectile, (Vector2)transform.position + offset * transform.localScale.x, Quaternion.identity);
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x * transform.localScale.x, velocity.y);
        }
    }
    IEnumerator CanShoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(wait);
        canShoot = true;
    }
}
