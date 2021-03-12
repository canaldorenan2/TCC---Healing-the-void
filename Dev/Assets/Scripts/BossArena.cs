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
            colossus.Destino();
            colossus.animator.SetBool("Run", true);
        }
    }
}
