using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunPlayer : MonoBehaviour
{
    IEnumerator Stun(Player player)
    {
        player.enabled = false;
        yield return new WaitForSeconds(5);
        player.enabled = true;
    }
}
