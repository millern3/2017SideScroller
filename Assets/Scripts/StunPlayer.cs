using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunPlayer : MonoBehaviour 
{
    protected new Rigidbody2D rigidbody2D;
    protected new Collider2D collider2D;

    IEnumerator Stun(Player player)
    {
        var renderer = player.GetComponent<SpriteRenderer>();
        var animator = player.GetComponent<Animator>();

        player.enabled = false;
        if (animator != null)
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
        player.enabled = true;
    }


}
