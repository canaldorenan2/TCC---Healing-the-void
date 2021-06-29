using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossArena : MonoBehaviour
{

    // public GameObject player;

    public Colossus colossus;

    public AudioSource audio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            colossus.playerNaArena = true;
            colossus.animator.SetBool("Run", true);
            audio.Play();
            colossus.hudBoss.SetActive(true);
            //colossus.hudExtensao.SetActive(true);
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
