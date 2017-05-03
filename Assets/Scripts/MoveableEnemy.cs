using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableEnemy: Enemy {

    public LayerMask enemyMask;
    public float speed;
    Rigidbody2D Body;
    Transform Trans;
    float Width;

	// Use this for initialization
	void Start ()
    {
        Trans = this.transform;
        Body = this.GetComponent<Rigidbody2D>();
        Width = this.GetComponent<SpriteRenderer>().bounds.extents.x;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 lineCastPos = Trans.position - Trans.right * Width;

        bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down, enemyMask);
       
        
       //if theres no ground
        if (!isGrounded)
        {
            Vector3 currRot = Trans.eulerAngles;
            currRot.y += 180;
            Trans.eulerAngles = currRot;
        }

        //Always move forward
        Vector2 Vel = Body.velocity;
        Vel.x = -Trans.right.x * speed;
        Body.velocity = Vel;
	}
}
