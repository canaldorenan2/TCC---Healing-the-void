using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CausaDano : MonoBehaviour
{
    Dragao dragon;
    ThirdPersonMovement player;

    Griffo griffo;

    float dano;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            griffo = GameObject.Find("HIPPOGRIFF_LEGACY").GetComponent<Griffo>();
        }
        else
        {
            dragon = GameObject.Find("Dragon").GetComponent<Dragao>();
        }

        
        
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


            if (this.tag == "SamuraiInimigo")
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
