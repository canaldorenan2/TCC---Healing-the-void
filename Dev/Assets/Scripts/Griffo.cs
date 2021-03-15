using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Griffo : MonoBehaviour
{

    float vida, resistencia;
    int dano;

    bool tangivel;

    bool atacando;

    bool combate;

    ThirdPersonMovement player;
    SofreDano scriptCalculaDano;

    // Start is called before the first frame update
    void Start()
    {
        tangivel = false;
        atacando = false;
        combate = false;
        vida = 150;
        resistencia = 15;
        dano = 25;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Sofre Dano
        if(other.gameObject.name == "Katana")
        {
            if ((player.atacando == true) && (tangivel))
            {
                vida = scriptCalculaDano.CausaDano(player.dano, vida, resistencia);
            }
        }

        // Causa Dano

        if (other.gameObject.name == "Player")
        {
            if (atacando)
            {
                player.vida = scriptCalculaDano.CausaDano(dano, player.vida, player.resistencia);
            }
        }
    }
}
