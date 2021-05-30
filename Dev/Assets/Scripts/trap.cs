using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour
{


    public ThirdPersonMovement player;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.vida -= 50;
        }
    }
}
