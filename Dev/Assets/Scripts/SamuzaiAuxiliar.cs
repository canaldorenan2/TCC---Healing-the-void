using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamuzaiAuxiliar : MonoBehaviour
{
    public Samuzai samuzai;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            samuzai.playerAround = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            samuzai.playerAround = false;
        }
    }
}
