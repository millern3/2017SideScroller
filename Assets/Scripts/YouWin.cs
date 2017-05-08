using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouWin : GM {

    public GameObject youWin;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (enabled)
        {
            youWin.SetActive(true);
        }

    }
}
