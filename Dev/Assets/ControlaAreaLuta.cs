using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaAreaLuta : MonoBehaviour
{
    public Griffo scriptGriffo;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            scriptGriffo.playerAround = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            scriptGriffo.playerAround = false;
        }
    }
}
