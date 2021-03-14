using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossArena : MonoBehaviour
{

    // public GameObject player;

    public Colossus colossus;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            colossus.playerNaArena = true;
            colossus.animator.SetBool("Run", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            colossus.playerNaArena = false;
        }
    }
}
