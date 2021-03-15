using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CausaDano : MonoBehaviour
{
    Dragao dragon;
    ThirdPersonMovement player;

    float dano;

    void Start()
    {
        dragon = GameObject.Find("Dragon").GetComponent<Dragao>();
        player = GameObject.Find("ThirdPersonPlayer").GetComponent<ThirdPersonMovement>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("pt1");
        if (other.tag == "Player")
        {
            Debug.Log("pt2");
            if (this.tag == "Colossus")
            {
                Debug.Log("Dano aplicado");
                dano = 25;
                player.vida = player.vida - (dano - (player.resistencia / 4));
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (this.tag == "Dragon")
            {
                dano = 0.5f;
                player.vida = player.vida - (dano - (player.resistencia / 4));
            }
        }
    }
}
