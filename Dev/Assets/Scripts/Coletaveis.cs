using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coletaveis : MonoBehaviour
{
    
    bool leaf, fire, water, air, earth;

    public Text text;

    ThirdPersonMovement scriptPlayer;

    //public AudioSource flautaColetaveis;


    void Start()
    {

        scriptPlayer = GameObject.Find("ThirdPersonPlayer").GetComponent<ThirdPersonMovement>();

        if (this.tag == "Leaf")
        {
            leaf = true;
        }
        if (this.tag == "Fire")
        {
            fire = true;
        }
        if (this.tag == "Water")
        {
            water = true;
        }
        if (this.tag == "Air")
        {
            air = true;
        }
        if (this.tag == "Earth")
        {
            earth = true;
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            text.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                // Não sei por que não esta funcionando
                //flautaColetaveis.Play();

                if (leaf)
                {
                    scriptPlayer.vida += 25;
                }

                if (fire)
                {
                    scriptPlayer.dano += 2;
                    scriptPlayer.coletaveisAudio.Play();
                    scriptPlayer.fogo += 1;
                }

                if (water)
                {
                    scriptPlayer.tempoParaRegen -= 1;
                    scriptPlayer.coletaveisAudio.Play();
                    scriptPlayer.agua += 1;
                }

                if (air)
                {
                    scriptPlayer.speed += 2;
                    scriptPlayer.coletaveisAudio.Play();
                    scriptPlayer.ar += 1;
                }

                if (earth)
                {
                    scriptPlayer.resistencia += 1;
                    scriptPlayer.coletaveisAudio.Play();
                    scriptPlayer.terra += 1;
                }
                //scriptPlayer.coletaveisAudio.Play();
                this.gameObject.transform.Translate(0, -10, 0);
                this.gameObject.SetActive(false);
                text.gameObject.SetActive(false);
                
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        text.gameObject.SetActive(false);
    }
}
