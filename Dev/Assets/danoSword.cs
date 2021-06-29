using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class danoSword : MonoBehaviour
{
    public ThirdPersonMovement player;
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("X1 noob");
        player.vida -= 30;
    }
}
