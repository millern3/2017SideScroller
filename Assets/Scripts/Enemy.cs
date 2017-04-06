using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	void OnCollisionEnter2D(Collision2D coll)
	{
		var player = coll.gameObject.GetComponent<player>();
		if (player != null) 
		{
			player.GetOut ();
		}
	}